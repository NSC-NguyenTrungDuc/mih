package nta.med.data.dao.emr;

public interface EmrTagRelationRepositoryCustom {
	public boolean isExisted(String tagChild, String tagParent, String templateId, String hospCode);
}
