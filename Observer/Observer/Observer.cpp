#include <iostream>
#include <list>
#include <string>
using namespace std;

class IObserver {
public:
	virtual ~IObserver() {};
	virtual void Update(const std::string &message_from_subject) = 0;
};

class IRoom {
public:
	virtual ~IRoom() {};
	virtual void Attach(IObserver *observer) = 0;
	virtual void Detach(IObserver *observer) = 0;
	virtual void Notify() = 0;
};

class Room : public IRoom {
public:
	void change1() {
		cout << "\nPrize rize up on 500$\n" << endl;
	}
	void change2() {
		cout << "\nRoom will be empty from 23.05\n" << endl;
	}
	void change3() {
		cout << "\nYou can stay in this room only for 3 days\n" << endl;
	}
	virtual ~Room() {
		cout << "Goodbye, I was the Subject.\n";
	}
	void Attach(IObserver *observer) override {
		list_observer_.push_back(observer);
	}
	void Detach(IObserver *observer) override {
		list_observer_.remove(observer);
	}
	void Notify() override {
		list<IObserver *>::iterator iterator = list_observer_.begin();
		HowManyObserver();
		while (iterator != list_observer_.end()) {
			(*iterator)->Update(message_);
			++iterator;
		}
	}

	void CreateMessage(std::string message = "Empty") {
		this->message_ = message;
		Notify();
	}
	void HowManyObserver() {
		cout << "There are " << list_observer_.size() << " observers in the list.\n";
	}
	void SomeBusinessLogic() {
		this->message_ = "change message message";
		Notify();
		cout << "I'm about to do some thing important\n";
	}

private:
	list<IObserver *> list_observer_;
	string message_;
};

class Observer : public IObserver {
public:
	Observer(Room &subject) : subject_(subject) {
		this->subject_.Attach(this);
		cout << "Hi, I'm the Observer \"" << ++Observer::static_number_ << "\".\n";
		this->number_ = Observer::static_number_;
	}
	virtual ~Observer() {
		cout << "Goodbye, I was the Observer \"" << this->number_ << "\".\n";
	}

	void Update(const std::string &message_from_subject) override {
		message_from_subject_ = message_from_subject;
		PrintInfo();
	}
	void RemoveMeFromTheList() {
		subject_.Detach(this);
		cout << "Observer \"" << number_ << "\" removed from the list.\n";
	}
	void PrintInfo() {
		cout << "Observer \"" << this->number_ << "\": " << this->message_from_subject_ << "\n";
	}

private:
	std::string message_from_subject_;
	Room &subject_;
	static int static_number_;
	int number_;
};

int Observer::static_number_ = 0;

void ClientCode() {
	Room *room = new Room;
	Observer *observer1 = new Observer(*room);
	Observer *observer2 = new Observer(*room);
	Observer *observer3 = new Observer(*room);
	Observer *observer4 = new Observer(*room);
	Observer *observer5 = new Observer(*room);

	room->CreateMessage("I want book this room!");

	room->change1();
	observer3->RemoveMeFromTheList();
	observer5->RemoveMeFromTheList();
	room->CreateMessage("We still want book this room!");

	room->change2();
	observer2->RemoveMeFromTheList();
	room->CreateMessage("It's normal date for me");
	
	room->change3();
	observer4->RemoveMeFromTheList();
	room->CreateMessage("It's enough for me");

	cout << endl;
	room->CreateMessage("I book this room!");
	observer1->RemoveMeFromTheList();
	cout << endl;

	delete observer5;
	delete observer4;
	delete observer3;
	delete observer2;
	delete observer1;
	delete room;
}

int main() {
	ClientCode();
	system("pause");
	return 0;
}