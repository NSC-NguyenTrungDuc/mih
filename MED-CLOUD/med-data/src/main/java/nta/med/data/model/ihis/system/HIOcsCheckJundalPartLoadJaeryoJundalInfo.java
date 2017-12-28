package nta.med.data.model.ihis.system;

public class HIOcsCheckJundalPartLoadJaeryoJundalInfo {
	private String checkJundal;
	private String loadJaeryoJundal;

	public HIOcsCheckJundalPartLoadJaeryoJundalInfo(String checkJundal,
			String loadJaeryoJundal) {
		super();
		this.checkJundal = checkJundal;
		this.loadJaeryoJundal = loadJaeryoJundal;
	}

	public String getCheckJundal() {
		return checkJundal;
	}

	public void setCheckJundal(String checkJundal) {
		this.checkJundal = checkJundal;
	}

	public String getLoadJaeryoJundal() {
		return loadJaeryoJundal;
	}

	public void setLoadJaeryoJundal(String loadJaeryoJundal) {
		this.loadJaeryoJundal = loadJaeryoJundal;
	}

}
