class Rectangle : Shape {
    private double _length;
    private double _width;

    public override double GetArea() {
        return _length * _width;
    }
}