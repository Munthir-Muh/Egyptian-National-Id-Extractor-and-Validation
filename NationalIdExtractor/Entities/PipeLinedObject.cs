using System;
using System.Collections.Generic;
using System.Text;

namespace NationalIdExtraction
{
    public class PipeLinedObject<T>
    {
        public T CurrentObject { get; private set; }
        public PipeLinedObject(T currentObject)
        {
            this.CurrentObject = currentObject;
        }

        public PipeLinedObject<T> Pipe(Action<T> pipedAction)
        {
            pipedAction(CurrentObject);

            return this;
        }

        public T Close()
        {
            return CurrentObject;
        }
    }
}
