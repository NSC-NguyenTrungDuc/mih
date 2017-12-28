package nta.med.data.dao.medi.bas;

import java.util.List;

import nta.med.data.model.ihis.bass.BAS0501U00CareFormTemplateInfo;

public interface Bas0501RepositoryCustom {
	public List<BAS0501U00CareFormTemplateInfo> getBas0501CareFormTemplate(String hospCode, String tplCode, String language);
	
	public String getOCS2015U00GetHtmlContent(String hospCode, String language);
}
