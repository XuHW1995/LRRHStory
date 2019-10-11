public class SingleTon<T> where T : new()
{
    private static T m_instance;
    public static T instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = new T();
                return m_instance;
            }
            else
                return m_instance;
        }
    }
}
