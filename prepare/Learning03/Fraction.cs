class Fraction {
    private int _top;
    private int _bottom;

    Fraction() {

    }

    Fraction(int wholeNumber) {

    }

    Fraction(int top, int bottom) {

    }

    public int GetTop() {
        return _top;
    }

    public void SetTop(int top) {
        _top =  top;
    }

    public int GetBottom() {
        return _bottom;
    }

    public void SetBottom(int bottom) {
        _bottom =  bottom;
    }

    public string GetFractionString() {
        return _top+"/"+_bottom;
    }

    public float GetDecimalValue() {
        return _top / _bottom;
    }


}