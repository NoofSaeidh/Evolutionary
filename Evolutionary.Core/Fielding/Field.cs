using Evolutionary.Core.Entities;
using Evolutionary.Core.Global;
using Evolutionary.Core.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Evolutionary.Core.Fielding
{
    public class Field : IEnumerable<KeyValuePair<Index2d, FieldCell>>
    {
        private readonly FieldCell[,] _items;

        public Field(Index2d size)
        {
            Size = size;
            _items = new FieldCell[size.X, size.Y];
        }

        public FieldCell this[Index2d index]
        {
            get
            {
                ThrowHelper.Check_ArgumentOutOfRange(index, Size, nameof(index));
                return _items[index.X, index.Y];
            }
            private set
            {
                ThrowHelper.Check_ArgumentOutOfRange(index, Size, nameof(index));
                _items[index.X, index.Y] = value;
            }
        }

        public Position? GetPosition(Entity entity)
        {
            ThrowHelper.Check_ArgumentNull(entity, nameof(entity));
            foreach (var (_, cell) in this)
            {
                if (cell.Entity == entity)
                    return cell.EntityPosition;
            }
            return null;
        }

        public bool AddEntity(Entity entity, Position position)
        {
            ThrowHelper.Check_ArgumentNull(entity, nameof(entity));
            if (position.Start.X < 0
             || position.End.X >= Size.X
             || position.Start.Y < 0
             || position.End.Y >= Size.Y)
                return false;

            var count = position.GetIndexesCount();
            var list = new List<(Index2d, FieldCell)>(count);

            foreach (var index in position.GetIndexes())
            {
                var cell = this[index];
                if (cell.Entity != null)
                    return false;
                list.Add((index, new FieldCell(position, entity)));
            }
            foreach (var (index, cell) in list)
            {
                this[index] = cell;
            }
            return true;
        }

        public bool MoveEntity(Entity entity, Position newPosition)
        {
            ThrowHelper.Check_ArgumentNull(entity, nameof(entity));
            if (newPosition.Start.X < 0
             || newPosition.End.X >= Size.X
             || newPosition.Start.Y < 0
             || newPosition.End.Y >= Size.Y)
                return false;

            var count = newPosition.GetIndexesCount();
            var list = new List<(Index2d, FieldCell, bool toRemove)>(count);

            var newIndexes = newPosition.GetIndexes().ToArray();

            foreach (var (index, cell) in this)
            {
                if (newIndexes.Contains(index))
                {
                    if (cell.Entity != null)
                    {
                        // already on place - no need to move
                        if (cell.Entity == entity)
                            continue;
                        // another entity
                        else
                            return false;
                    }
                    else
                        list.Add((index, new FieldCell(newPosition, entity), false));
                }
                else if (cell.Entity == entity)
                    list.Add((index, default, true));
            }
            foreach (var (index, cell, toRemove) in list)
            {
                this[index] = toRemove ? (default) : cell;
            }
            return true;
        }

        public Index2d Size { get; }


        public IEnumerator<KeyValuePair<Index2d, FieldCell>> GetEnumerator()
        {
            for (int x = 0; x < Size.X; x++)
            {
                for (int y = 0; y < Size.Y; y++)
                {
                    yield return new KeyValuePair<Index2d, FieldCell>((x, y), _items[x, y]);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
