package typecheck;

// this class represents the left hand side of an equation whose type is to be determined
public class RuleInput {
	private Type firstOperand;
	private Type secondOperand;
	private TerminalSymbol operator;

	// a constructor that deals with two operand operations and takes Type
	public RuleInput(Type firstOperand, Type secondOperand, TerminalSymbol operator) {
		this.firstOperand = firstOperand;
		this.secondOperand = secondOperand;
		this.operator = operator;
	}

	// a constructor that deals with two operand operations and takes Objects
	public RuleInput(Object firstOperand, Object secondOperand, TerminalSymbol operator) {
		this.firstOperand = new Type(firstOperand);
		this.secondOperand = new Type(secondOperand);
		this.operator = operator;
	}

	// a constructor that deals with unitary operations and takes Type
	public RuleInput(Type firstOperand, TerminalSymbol operator) {
		this.firstOperand = firstOperand;
		this.operator = operator;
	}

	// a constructor that deal with unitary operations and takes Object
	public RuleInput(Object firstOperand, TerminalSymbol operator) {
		this.firstOperand = new Type(firstOperand);
		this.operator = operator;
	}

	boolean equals(RuleInput input) {
	    if(this.secondOperand == null || input.getSecondOperand() == null)
	        return unitaryEquals(input);
	    else
	        return twoOperandEquals(input);
	}

	//helper method for equals
	private boolean unitaryEquals(RuleInput input) {
        if(!firstOperand.equals(input.getFirstOperand())) return false;
        if(!operator.equals(input.getOperator())) return false;
        else return true;
    }

    //helper method for equals
    private boolean twoOperandEquals(RuleInput input) {
        if(!firstOperand.equals(input.getFirstOperand())) return false;
        if(!secondOperand.equals(input.getSecondOperand())) return false;
        if(!operator.equals(input.getOperator())) return false;
        else return true;
    }

	public Type getFirstOperand() {
		return firstOperand;
	}

	public void setFirstOperand(Type firstOperand) {
		this.firstOperand = firstOperand;
	}

	public Type getSecondOperand() {
		return secondOperand;
	}

	public void setSecondOperand(Type secondOperand) {
		this.secondOperand = secondOperand;
	}

	public TerminalSymbol getOperator() {
		return operator;
	}

	public void setOperator(TerminalSymbol operator) {
		this.operator = operator;
	}

	
}
