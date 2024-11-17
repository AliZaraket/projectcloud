#include "linetype.h"
linetype::linetype(float A, float B, float C) {
	a = A; b = B; c = C;
}
float linetype::slope() const {
	if (b != 0)
		return -a / b;
	else
		return 99999;
}
bool linetype::is_horizontal() const {
	return (a == 0);
}
bool linetype::is_vertical() const {
	return (b == 0);
}
void linetype::intersection(linetype& line1,float& x, float& y) {
	if (this->slope() != line1.slope()) {
		x = ((line1.c*b) - (c*line1.b)) / ((line1.a*b) - (a*line1.b));
		y = ((-a / b) * x) + (c / b);
	}
}
ostream& operator<<(ostream& osobject, linetype& line1) {
	osobject << "Line eqn:" << line1.a << "x + " << line1.b << "y = " << line1.c << endl;;
	return osobject;
}
istream& operator>>(istream& isobject, linetype& line1) {
	isobject >> line1.a >> line1.b >> line1.c;
	return isobject;
}
bool linetype::operator++() {
	if (this->slope() != 0) {
		a = a - b;
		return 1;
	}
	else
		return 0;
}
bool linetype::operator--() {
	if (this->slope() != 0) {
		a = a + b;
		return 1;
	}
	else
		return 0;
}
bool linetype::operator==(linetype& line) {
	return ((a == line.a) && (b == line.b) && (c == line.c));
}
bool linetype::operator||(linetype& line) {
	return (this->slope() == line.slope());
}
bool linetype::operator&&(linetype& line) {
	return ((line.is_horizontal() && this->is_vertical()) || (this->is_horizontal() && line.is_vertical()) || (line.slope() * this->slope() == -1));
}
linetype::linetype(linetype& line) {
	a = line.a;
	b = line.b;
	c = line.c;
}

