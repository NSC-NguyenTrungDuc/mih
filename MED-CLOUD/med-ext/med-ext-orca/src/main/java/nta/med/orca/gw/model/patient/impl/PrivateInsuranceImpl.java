package nta.med.orca.gw.model.patient.impl;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

import org.springframework.util.CollectionUtils;
import org.w3c.dom.Document;
import org.w3c.dom.Node;

import nta.med.core.utils.CommonUtils;
import nta.med.ext.support.proto.PatientModelProto;
import nta.med.orca.gw.api.contracts.message.HealthInsuranceInfo;
import nta.med.orca.gw.api.contracts.message.PatientInfo;
import nta.med.orca.gw.api.contracts.message.PublicInsuranceInfo;
import nta.med.orca.gw.glossary.OrcaPath;
import nta.med.orca.gw.model.patient.PrivateInsurance;
import nta.med.orca.gw.xpath.XPathAPI;

public class PrivateInsuranceImpl implements PrivateInsurance {

	private String startDate;
	private String bunho;
	private String budamjaBunho ;
	private String gongbiCode;
	private String sugubjaBunho ;
	private String endDate;
	private String remark;
	private String lastCheckDate;
	private String gongbiName;
	private String retrieveYn;
	private String oldStartDate;
	private String endYn;
	private String dataRowState;
	
	@Override
	public PatientModelProto.PrivateInsurance toProto() {

		PatientModelProto.PrivateInsurance.Builder builder = PatientModelProto.PrivateInsurance.newBuilder();
		builder.setStartDate(startDate);
		builder.setBunho(org.apache.commons.lang3.StringUtils.leftPad(bunho, 9, "0"));
		builder.setBudamjaBunho(budamjaBunho);
		builder.setGongbiCode(gongbiCode);
		builder.setSugubjaBunho(sugubjaBunho);
		builder.setEndDate(endDate);
		builder.setRemark(remark);
		builder.setLastCheckDate(lastCheckDate);
		builder.setGongbiName(gongbiName);
		builder.setRetrieveYn(retrieveYn);
		builder.setOldStartDate(oldStartDate);
		builder.setEndYn(endYn);
		
		return builder.build();
	}

	@Override
	public List<PrivateInsurance> copyFromPatientInfo(PatientInfo pt) throws Exception{
		List<PrivateInsurance> privateInsList = new ArrayList<PrivateInsurance>();
		List<HealthInsuranceInfo> healthInsList = pt.getHealthInsuranceInformation();
		List<PublicInsuranceInfo> publicInsList = new ArrayList<PublicInsuranceInfo>();
		List<PublicInsuranceInfo> publicInsDistinctList = new ArrayList<PublicInsuranceInfo>();
		
		if(!CollectionUtils.isEmpty(healthInsList)){
			for (HealthInsuranceInfo healthIns : healthInsList) {
				List<PublicInsuranceInfo> publicInsListItem =  healthIns.getPublicInsuranceInformation();
				if(!CollectionUtils.isEmpty(publicInsListItem)){
					publicInsList.addAll(publicInsListItem);
				}
			}
		}
		
		if(!CollectionUtils.isEmpty(publicInsList)){
			for (PublicInsuranceInfo info : publicInsList) {
				if(!existInList(publicInsDistinctList, info)){
					publicInsDistinctList.add(info);
				}
			}
			
			for (PublicInsuranceInfo info : publicInsDistinctList) {
				PrivateInsurance gongbi = new PrivateInsuranceImpl();
				gongbi.setStartDate(info.getCertificateIssuedDate().replace("-", "/"));
				gongbi.setEndDate(info.getCertificateExpiredDate().replace("-", "/"));
				gongbi.setBunho(pt.getPatientId());
				gongbi.setBudamjaBunho(info.getPublicInsurerNumber() == null ? "" : info.getPublicInsurerNumber());
				gongbi.setGongbiCode(info.getPublicInsuranceClass());
				gongbi.setSugubjaBunho(info.getPublicInsuredPersonNumber() == null ? "" : info.getPublicInsuredPersonNumber());
				gongbi.setRemark("");
				gongbi.setLastCheckDate("");
				gongbi.setGongbiName(info.getPublicInsuranceName() == null ? "" : info.getPublicInsuranceName());
				gongbi.setRetrieveYn("N");
				gongbi.setOldStartDate("");
				gongbi.setEndYn("N");
				gongbi.setDataRowState("");
				
				privateInsList.add(gongbi);
			}
		}
		
		return privateInsList;
	}
	
	@Override
	public List<PrivateInsurance> toModelList(Document doc) throws Exception {
		List<PrivateInsurance> gongbiList = new ArrayList<PrivateInsurance>();

    	String bunho = XPathAPI.selectSingleNodeAsString(doc, OrcaPath.BUNHO_PATH.getPath());
		bunho = bunho == null ? "" : CommonUtils.formatMmlString(bunho);

		String retrieveYn = "N";
		String endYn = "N";

		// get all health insurance module
		List<Node> healthInsModules = XPathAPI.selectListOfNodes(doc, OrcaPath.HEALTH_INSURANCE_MODULE_PATH.getPath());
		for (Node healthInsNode : healthInsModules) {
			Document healthDoc = XPathAPI.node2Document(healthInsNode);
			HashMap<String, String> nsp = new HashMap<String, String>();
			nsp.put("mmlHi", "http://www.medxml.net/MML/ContentModule/HealthInsurance/1.1");
			
			// get all public insurance item for each health insurance module 
			List<Node> publicInsItems = XPathAPI.selectListOfNodes(healthDoc, OrcaPath.PUBLIC_INSURANCE_ITEM_PATH.getPath(), nsp);
			for (Node publicInsNode : publicInsItems) {
				Document publicInsDoc = XPathAPI.node2Document(publicInsNode);
				
				String startDate = XPathAPI.selectSingleNodeAsString(publicInsDoc, OrcaPath.PUBLIC_INSURANCE_ITEM_START_DATE_PATH.getPath(), nsp);
				String endDate = XPathAPI.selectSingleNodeAsString(publicInsDoc, OrcaPath.PUBLIC_INSURANCE_ITEM_END_DATE_PATH.getPath(), nsp);
				String gongbiName = XPathAPI.selectSingleNodeAsString(publicInsDoc, OrcaPath.PUBLIC_INSURANCE_ITEM_GONGBI_NAME_PATH.getPath(), nsp);
				gongbiName = gongbiName == null ? "" : CommonUtils.formatMmlString(gongbiName);
				
				String budamjaBunho = XPathAPI.selectSingleNodeAsString(publicInsDoc, OrcaPath.PUBLIC_INSURANCE_BUDAMJA_BUNHO_PATH.getPath(), nsp);
				budamjaBunho = budamjaBunho == null ? "" : CommonUtils.formatMmlString(budamjaBunho);
				if(OrcaPath.MIKINYU.getPath().equals(budamjaBunho)){
					budamjaBunho = "";
				}
				
				String sugubjaBunho = XPathAPI.selectSingleNodeAsString(publicInsDoc, OrcaPath.PUBLIC_INSURANCE_SUGUBJA_BUNHO.getPath(), nsp);
				sugubjaBunho = sugubjaBunho == null ? "" : CommonUtils.formatMmlString(sugubjaBunho);
				if(OrcaPath.MIKINYU.getPath().equals(sugubjaBunho)){
					sugubjaBunho = "";
				}
				
				if(startDate != null || endDate != null){
					PrivateInsurance gongbi = new PrivateInsuranceImpl();
					
					gongbi.setStartDate(CommonUtils.formatMmlString(startDate).replace("-", "/"));
					gongbi.setEndDate(CommonUtils.formatMmlString(endDate).replace("-", "/"));
					gongbi.setBunho(bunho);
					gongbi.setBudamjaBunho(budamjaBunho);
					gongbi.setGongbiCode("");
					//gongbi.setSugubjaBunho("");
					gongbi.setSugubjaBunho(sugubjaBunho);
					gongbi.setRemark("");
					gongbi.setLastCheckDate("");
					gongbi.setGongbiName(gongbiName);
					gongbi.setRetrieveYn(retrieveYn);
					gongbi.setOldStartDate("");
					gongbi.setEndYn(endYn);
					
					gongbiList.add(gongbi);
				}
			}
		}
		
		List<PrivateInsurance> gongbiListDistinct = new ArrayList<PrivateInsurance>();
		for (PrivateInsurance item : gongbiList) {
			if(!isExistsGongbiInList(gongbiListDistinct, item)){
				gongbiListDistinct.add(item);
			}
		}
		
    	return gongbiListDistinct;
	}
	
	@Override
	public String getStartDate() {
		return startDate;
	}

	@Override
	public void setStartDate(String startDate) {
		this.startDate = startDate;
	}

	@Override
	public String getBunho() {
		return bunho;
	}

	@Override
	public void setBunho(String bunho) {
		this.bunho = bunho;
	}

	@Override
	public String getBudamjaBunho() {
		return budamjaBunho;
	}

	@Override
	public void setBudamjaBunho(String budamjaBunho) {
		this.budamjaBunho = budamjaBunho;
	}

	@Override
	public String getGongbiCode() {
		return gongbiCode;
	}

	@Override
	public void setGongbiCode(String gongbiCode) {
		this.gongbiCode = gongbiCode;
	}

	@Override
	public String getSugubjaBunho() {
		return sugubjaBunho;
	}

	@Override
	public void setSugubjaBunho(String sugubjaBunho) {
		this.sugubjaBunho = sugubjaBunho;
	}

	@Override
	public String getEndDate() {
		return endDate;
	}

	@Override
	public void setEndDate(String endDate) {
		this.endDate = endDate;
	}

	@Override
	public String getRemark() {
		return remark;
	}

	@Override
	public void setRemark(String remark) {
		this.remark = remark;
	}

	@Override
	public String getLastCheckDate() {
		return lastCheckDate;
	}

	@Override
	public void setLastCheckDate(String lastCheckDate) {
		this.lastCheckDate = lastCheckDate;
	}

	@Override
	public String getGongbiName() {
		return gongbiName;
	}

	@Override
	public void setGongbiName(String gongbiName) {
		this.gongbiName = gongbiName;
	}

	@Override
	public String getRetrieveYn() {
		return retrieveYn;
	}

	@Override
	public void setRetrieveYn(String retrieveYn) {
		this.retrieveYn = retrieveYn;
	}

	@Override
	public String getOldStartDate() {
		return oldStartDate;
	}

	@Override
	public void setOldStartDate(String oldStartDate) {
		this.oldStartDate = oldStartDate;
	}

	@Override
	public String getEndYn() {
		return endYn;
	}

	@Override
	public void setEndYn(String endYn) {
		this.endYn = endYn;
	}

	@Override
	public String getDataRowState() {
		return dataRowState;
	}

	@Override
	public void setDataRowState(String dataRowState) {
		this.dataRowState = dataRowState;
	}
	
	private boolean isExistsGongbiInList(List<PrivateInsurance> gongbiList, PrivateInsurance gongbi){
		for (PrivateInsurance item : gongbiList) {
			if(item.getBunho().equals(gongbi.getBunho()) 
					&& item.getGongbiName().equals(gongbi.getGongbiName()) && item.getStartDate().equals(gongbi.getStartDate())){
				return true;
			}
		}
		
		return false;
	}
	
	private boolean existInList(List<PublicInsuranceInfo> publicInsList, PublicInsuranceInfo ins){
		for (PublicInsuranceInfo info : publicInsList) {
			if(info.getPublicInsuranceClass().equals(ins.getPublicInsuranceClass())){
				return true;
			}
		}
		
		return false;
	}
}
