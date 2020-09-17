package typecheck;

import static org.junit.jupiter.api.Assertions.*;

import java.io.IOException;

import org.junit.jupiter.api.Test;

class TypeCheckerTest {
	
	

	@Test
	 void test() throws IOException {
		myInteger testInt = new myInteger();
		TypeChecker testCheck = new TypeChecker();
		ParseTreeNode<myInteger>  testNode = new ParseTreeNode(testInt);
		System.out.println(testCheck.getType(testNode));
	}

}
