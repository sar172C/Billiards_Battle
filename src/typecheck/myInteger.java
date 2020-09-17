package typecheck;

public class myInteger  implements TypeCheckable {

	@Override
	public Type getType() {
		return new Type(new Integer(5));
	}

}
