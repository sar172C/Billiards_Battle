package typecheck;

import java.util.HashMap;

public class Rules {

	private HashMap<RuleInput, Type> ruleSet = new HashMap<>();

	void newRule(Object leftOperand, Object rightOperand, TerminalSymbol operator, Object output) {
		Type outputType =  new Type(output);
		RuleInput expression = new RuleInput(leftOperand, rightOperand, operator);
		ruleSet.putIfAbsent(expression, outputType);
	}

	void newRule(Object unitaryOperand, TerminalSymbol operator, Object output) {
		Type outputType = new Type(output);
		RuleInput expression = new RuleInput(unitaryOperand, operator);
		ruleSet.putIfAbsent(expression, outputType);
	}

	public HashMap<RuleInput, Type> getRuleSet() {
		return ruleSet;
	}
}
