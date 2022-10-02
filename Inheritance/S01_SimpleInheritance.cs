namespace SimpleInheritance
{
    class BaseClass
    {
        public int publicField;
        private int privateField;
        protected int protectedField;

        public void PublicMethod()
        {
            Console.WriteLine(publicField);
            Console.WriteLine(privateField);
            Console.WriteLine(protectedField);
        }
    }

    class DerivedClass : BaseClass
    {
        public int anotherPublicField;

        public void AnotherPublicMethod()
        {
            Console.WriteLine(publicField);
            //Console.WriteLine(privateField);
            Console.WriteLine(protectedField);
            Console.WriteLine(anotherPublicField);
        }
    }

    class Program
    {
        static void MainX(string[] args)
        {
            var obj = new DerivedClass();
            Console.WriteLine(obj.publicField);
            //Console.WriteLine(obj.privateField);
            //Console.WriteLine(obj.protectedField);
            Console.WriteLine(obj.anotherPublicField);
        }
    }
}