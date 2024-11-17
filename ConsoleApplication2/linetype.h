#include<iostream>
#pragma once
using namespace std;

class linetype
{
	friend ostream& operator<<(ostream&, linetype&);
	friend istream& operator>>(istream&, linetype&);
private:
	float a, b, c;
public:
	float slope() const;
	bool is_horizontal() const;
	bool is_vertical() const;
	void intersection(linetype&,float& , float& );
	linetype(float , float , float );
	bool operator++();
	bool operator--();
	bool operator==(linetype&);
	bool operator||(linetype&);
	bool operator&&(linetype&);
	linetype(linetype&);
};

