namespace TDQueue
{
    /// <summary>
    /// 表示循环顺序队列
    /// </summary>
    /// <typeparam name="T">指定队列元素类型</typeparam>
    public class CircularSequenceQueue<T> : IQueue<T>
    {
        private int maxsize;       //循环顺序队列的容量
        private T[] data;          //数组，用于存储循环顺序队列中的数据元素
        private int front;         //指示最近一个已经离开队列的元素所占有的位置 循环顺序队列的队头
        private int rear;          //指示最近一个进入队列的元素的位置           循环顺序队列的队尾

        /// <summary>
        /// 索引器
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T this[int index]
        {
            get { return data[index]; }
            set { data[index] = value; }
        }

        #region 属性

        /// <summary>
        /// 容量
        /// </summary>
        public int MaxSize
        {
            get { return maxsize; }
            set { maxsize = value; }
        }

        /// <summary>
        /// 队头指示器
        /// </summary>
        public int Front
        {
            get { return front; }
            set { front = value; }
        }

        /// <summary>
        /// 队尾指示器
        /// </summary>
        public int Rear
        {
            get { return rear; }
            set { front = value; }
        }

        #endregion

        #region 构造

        /// <summary>
        /// 初始化为空的<seealso cref="Td.Queue.CircularSequenceQueue<typeparamref name="T"/>"/> 类的新实例。
        /// </summary>
        public CircularSequenceQueue() { }

        /// <summary>
        /// 初始化指定容器大小的<seealso cref="Td.Queue.CircularSequenceQueue<typeparamref name="T"/>"/> 类的新实例。
        /// </summary>
        /// <param name="size">容器大小</param>
        public CircularSequenceQueue(int size)
        {
            data = new T[size];
            maxsize = size;
            front = rear = -1;
        }

        #endregion

        /// <summary>
        /// 清空循环顺序列表
        /// </summary>
        public void Clear()
        {
            front = rear = -1;
        }

        /// <summary>
        /// 出队
        /// </summary>
        /// <returns></returns>
        public T DeQueue()
        {
            if (IsEmpty())
            {
                return default(T);
            }

            front = (front + 1) % maxsize;

            return data[front];
        }

        /// <summary>
        /// 入队
        /// </summary>
        /// <param name="elem"></param>
        public void EnQueue(T elem)
        {
            if (!IsFull())
            {
                rear = (rear + 1) % maxsize;

                data[rear] = elem;
            }
        }

        /// <summary>
        /// 获取队头数据元素
        /// </summary>
        /// <returns></returns>
        public T GetFront()
        {
            if (IsEmpty())
            {
                return default(T);
            }

            return data[(front + 1) % maxsize];//因为front从-1开始，所以在此+1
        }

        /// <summary>
        /// 获取队列长度
        /// </summary>
        /// <returns></returns>
        public int GetLength()
        {
            return IsFull() ? maxsize : (rear - front + maxsize) % maxsize;
        }

        /// <summary>
        /// 判断队列是否为空
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return front == rear;
        }

        /// <summary>
        /// 判断队列是否已满
        /// </summary>
        /// <returns></returns>
        public bool IsFull()
        {
            return (front == -1 && rear == maxsize - 1)//队头未开始取,队尾在容器极限的末位 --已满
                || ((rear + 1) % maxsize == front);//或，在容器权限时队尾往前移一位即是队头 --已满
        }
    }
}
