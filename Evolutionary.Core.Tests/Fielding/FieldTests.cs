using Evolutionary.Core.Entities;
using Evolutionary.Core.Fielding;
using Evolutionary.Core.Tests.Helpers;
using Evolutionary.Core.Tests.Mock;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Evolutionary.Core.Tests.Fielding
{
    [Trait("SUT", nameof(Field))]
    public class FieldTests
    {
        public static IEnumerable<object[]> DATA_GetEntities_Should_Return_All_Added_Entities()
        {
            var list = new List<int[]>();
            for (int i = 0; i < 20; i += 2)
            {
                for (int j = 0; j < 20; j += 2)
                {
                    list.Add(new[] { i, j, i + 1, j + 1 });
                }
            }
            yield return new object[]
            {
                list.ToArray()
            };
        }

        [Theory]
        [InlineData(new[] { 1, 1 })]
        [InlineData(new[] { 0, 0, 1, 1 }, new[] { 2, 2, 4, 4 })]
        [InlineData(new[] { 4, 6, 10, 10 }, new[] { 11, 11 }, new[] { 14, 13, 15, 15 }, new[] { 17, 17, 19, 19 })]
        [MemberData(nameof(DATA_GetEntities_Should_Return_All_Added_Entities))]
        public void GetEntities_Should_Return_All_Added_Entities(params int[][] indexesArrays)
        {
            var field = new Field((20, 20));
            int id = 0;
            var entities = indexesArrays.ToPositions().Select(i => (entity: new TestEntity { Id = id++ }, position: i)).ToList();

            foreach (var (entity, position) in entities)
            {
                if (!field.AddEntity(entity, position))
                    throw new TestDataException();
            }

            entities.Sort((l, r) => l.entity.Id.CompareTo(r.entity.Id));
            var assert = field.GetEntities().ToList();
            assert.Sort((l, r) => ((TestEntity)l.Entity).Id.CompareTo(((TestEntity)r.Entity).Id));

            assert.Should().HaveCount(entities.Count)
                .And.BeEquivalentTo(entities);
        }

        [Theory]
        [InlineData(new[] { 1, 1, 2, 3 })]
        [InlineData(new[] { 4, 4 })]
        [InlineData(new[] { 0, 0, 19, 19 })]
        public void AddEntity_Should_Place_Entity_On_Right_Cells(int[] positionAr)
        {
            var field = new Field((20, 20));
            var position = positionAr.ToPosition();
            var entity = new TestEntity();
            if (!field.AddEntity(entity, position))
                throw new TestExecutionException();

            field.GetEntities()
                 .Should()
                 .HaveCount(1)
                 .And.SatisfyRespectively((t) => t.Position.Should().Be(position));
            var indexes = position.GetIndexes();
            for (int x = 0; x < 20; x++)
            {
                for (int y = 0; y < 20; y++)
                {
                    if (indexes.Contains((x, y)))
                    {
                        field[(x, y)].Entity.Should().Be(entity);
                        field[(x, y)].EntityPosition.Should().Be(position);
                    }
                    else
                    {
                        field[(x, y)].Entity.Should().BeNull();
                    }
                }
            }
        }

    }
}
