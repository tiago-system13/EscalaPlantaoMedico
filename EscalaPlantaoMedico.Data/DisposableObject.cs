using System;
using System.Collections.Generic;
using System.Text;

namespace EscalaPlantaoMedico.Data
{
    public class DisposableObject : IDisposable
    {
        private bool disposedValue = false;

        private List<IDisposable> _compositions;

        protected DisposableObject(IEnumerable<IDisposable> compositions)
        {
            _compositions = new List<IDisposable>(compositions ?? throw new ArgumentException(nameof(compositions)));
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    foreach (var item in _compositions)
                    {
                        item.Dispose();
                    }
                }

                _compositions?.Clear();
                _compositions = null;
                disposedValue = true;
            }
            
        }

        DisposableObject()
        {
            Dispose(false);
        }

        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
