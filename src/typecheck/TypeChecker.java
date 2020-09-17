package typecheck;


import java.io.IOException;
import java.util.Objects;

public class TypeChecker {

    Rules ruleSet = new Rules();

    public Type getType(ParseTreeNode root) throws IOException {
        if(root.isLeaf() && !(root.getValue() instanceof TerminalSymbol))
            return root.getValue().getType();
        else //if we are in this case, the list must have been instantiated and cannot have a length of zero
            assert(root.getValue().getType()==null); // for a non-leaf node, the type should be expression
            return calculateType(root);
    }

	private Type calculateType(ParseTreeNode root) throws IOException{
	    if(root.getChildTwo() != null) {
            Type firstOperand = getType(root.getChildOne());
            Type secondOperand = getType(root.getChildOne());
            TerminalSymbol operator = (TerminalSymbol) root.getOperator().getValue();
            RuleInput input = new RuleInput(firstOperand, secondOperand, operator);
            return ruleSet.getRuleSet().get(input);
        }
        else if(root.getValue() instanceof TerminalSymbol)
            return null;
        else
            throw new IOException("the parse tree was not properly formatted");
        return output;
    }

    private boolean isTwoOperandOperation(ParseTreeNode node) {
        if(node.getChildOne() != null && node.getChildTwo() != null && node.getOperator() != null)
            return true;
        else
            return false;
    }

    private boolean isUnitaryOperation(ParseTreeNode node) {
        if(node.getChildOne() != null && node.getChildTwo() == null && node.getOperator() != null)
            return true;
        else
            return false;
    }
}
