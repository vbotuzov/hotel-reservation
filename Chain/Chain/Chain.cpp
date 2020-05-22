#include <iostream>
#include <string>
#include <vector>
using namespace std;

class Handler {
public:
	virtual Handler *SetNext(Handler *handler) = 0;
	virtual std::string Handle(std::string request) = 0;
};

class AbstractHandler : public Handler {
private:
	Handler *next_handler_;

public:
	AbstractHandler() : next_handler_(nullptr) {
	}
	Handler *SetNext(Handler *handler) override {
		this->next_handler_ = handler;
		return handler;
	}
	std::string Handle(std::string request) override {
		if (this->next_handler_) {
			return this->next_handler_->Handle(request);
		}

		return {};
	}
};

class TypeHandler : public AbstractHandler {
public:
	std::string Handle(std::string request) override {
		if (request == "Lux type") {
			return "Type: You will take " + request + ".\n";
		}
		else {
			return AbstractHandler::Handle(request);
		}
	}
};
class ÑapacityHandler : public AbstractHandler {
public:
	std::string Handle(std::string request) override {
		if (request == "on 3 person") {
			return "Capacity: Ypu wil take room " + request + ".\n";
		}
		else {
			return AbstractHandler::Handle(request);
		}
	}
};
class PrizeHandler : public AbstractHandler {
public:
	std::string Handle(std::string request) override {
		if (request == "low 1000$") {
			return "Prize: you will pay " + request + ".\n";
		}
		else {
			return AbstractHandler::Handle(request);
		}
	}
};

void ClientCode(Handler &handler) {
	std::vector<std::string> wishes = { "Lux type", "on 3 person", "low 1000$" };
	for (const std::string &f : wishes) {
		std::cout << "Client: I want room " << f << "?\n";
		const std::string result = handler.Handle(f);
		if (!result.empty()) {
			std::cout << "  " << result;
		}
		else {
			std::cout << "  " << f << " You take your room.\n";
		}
	}
}

int main() {
	TypeHandler *monkey = new TypeHandler;
	ÑapacityHandler *squirrel = new ÑapacityHandler;
	PrizeHandler *dog = new PrizeHandler;
	monkey->SetNext(squirrel)->SetNext(dog);
	std::cout << "Chain: Type > Capacity > Prize\n\n";
	ClientCode(*monkey);
	std::cout << "\n";
	delete squirrel;
	delete dog;
	system("pause");
	return 0;
}