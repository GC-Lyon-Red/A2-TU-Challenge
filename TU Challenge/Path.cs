using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TU_Challenge
{
    public struct Path
    {
        List<Vector2> _path;

        public Path(Vector2 start)
        {
            _path = new List<Vector2>();
            _path.Add(start);
        }

        public Path(Path oldPath, Vector2 newPosition)
        {
            _path = new List<Vector2>(oldPath._path);
            _path.Add(newPosition);
        }

        public List<Vector2> CompletePath => _path;

        public Vector2 LastElement => _path[_path.Count - 1];

        public bool IsComplete(Vector2 start, Vector2 end)
            => _path != null &&
            _path[0] == start &&
            _path[_path.Count - 1] == end;
    }
}
