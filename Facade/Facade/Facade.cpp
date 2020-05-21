#include <iostream>
#include <string>
using namespace std;

class Room1 {
public:
	string Type() const {
		return "Lux\n";
	}
	string Capacity() const {
		return "3 person\n";
	}
	string Prize() const {
		return "1000$\n";
	}
};

class Room2 {
public:
	string Type() const {
		return "Middle\n";
	}
	string Capacity() const {
		return "2 person\n";
	}
	string Prize() const {
		return "750$\n";
	}
};

class Room3 {
public:
	string Type() const {
		return "Usual\n";
	}
	string Capacity() const {
		return "1 person\n";
	}
	string Prize() const {
		return "500$\n";
	}
};

class Facade {
protected:
	Room1 *room1_;
	Room2 *room2_;
	Room3 *room3_;
	
public:
	Facade(Room1 *room1 = nullptr, Room2 *room2 = nullptr, Room3 *room3 = nullptr) {
		this->room1_ = room1;
		this->room2_ = room2;
		this->room3_ = room3;
	}
	~Facade() {
		delete room1_;
		delete room2_;
		delete room3_;
	}
	string Operation1() {
		string result = "Room1:\n";
		result += this->room1_->Type();
		result += this->room1_->Capacity();
		result += this->room1_->Prize();
		return result;
	}
	string Operation2() {
		string result = "Room2:\n";
		result += this->room2_->Type();
		result += this->room2_->Capacity();
		result += this->room2_->Prize();
		return result;
	}
	string Operation3(){
		string result = "Room3:\n";
		result += this->room3_->Type();
		result += this->room3_->Capacity();
		result += this->room3_->Prize();
		return result;
	}
};

void Client(Facade *facade) {
	cout << facade->Operation1();
	cout << facade->Operation2();
	cout << facade->Operation3();
}
int main() {
	Room1 *room1 = new Room1;
	Room2 *room2 = new Room2;
	Room3 *room3 = new Room3;
	Facade *facade = new Facade(room1, room2, room3);
	Client(facade);
	delete facade;
	system("pause");
	return 0;
}