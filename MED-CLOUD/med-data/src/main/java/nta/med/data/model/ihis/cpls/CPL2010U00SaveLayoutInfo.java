package nta.med.data.model.ihis.cpls;

public class CPL2010U00SaveLayoutInfo {
	private boolean save;
	private Integer jubsuCnt;

	public CPL2010U00SaveLayoutInfo(boolean save, Integer jubsuCnt) {
		super();
		this.save = save;
		this.jubsuCnt = jubsuCnt;
	}

	public boolean isSave() {
		return save;
	}

	public void setSave(boolean save) {
		this.save = save;
	}

	public Integer getJubsuCnt() {
		return jubsuCnt;
	}

	public void setJubsuCnt(Integer jubsuCnt) {
		this.jubsuCnt = jubsuCnt;
	}

}
