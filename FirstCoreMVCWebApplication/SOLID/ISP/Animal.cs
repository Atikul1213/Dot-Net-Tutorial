namespace FirstCoreMVCWebApplication.SOLID.ISP
{
    public abstract class Animal
    {
        public virtual string Name { get; set; }
        public double Weight { get; set; }
        public abstract void Eat();

        public abstract void Sleep();
        public abstract void Life();
    }
}
