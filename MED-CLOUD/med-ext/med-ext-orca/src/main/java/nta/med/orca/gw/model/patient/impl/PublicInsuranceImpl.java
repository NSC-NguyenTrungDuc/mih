package nta.med.orca.gw.model.patient.impl;

import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.OrcaUtils;
import nta.med.ext.support.proto.PatientModelProto;
import nta.med.orca.gw.api.contracts.message.HealthInsuranceInfo;
import nta.med.orca.gw.api.contracts.message.PatientInfo;
import nta.med.orca.gw.api.contracts.service.PatientInfoResponse;
import nta.med.orca.gw.glossary.OrcaPath;
import nta.med.orca.gw.model.patient.PublicInsurance;
import nta.med.orca.gw.xpath.XPathAPI;

import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.w3c.dom.Document;
import org.w3c.dom.Node;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

public class PublicInsuranceImpl implements PublicInsurance {

	private String startDate;
	private String bunho;
	private String suname;
	private String gubun1;
	private String gubunName1;
	private String johap;
	private String johapName;
	private String tel;
	private String gaein;
	private String gaeinNo;
	private String boninGubun;
	private String boninGubunName;
	private String piname;
	private String lastCheckDate;
	private String endDate;
	private String johapGubun;
	private String oldGubun;
	private String retrieveYn;
	private String oldStartDate;
	private String chuidukDate;
	private String endYn;
	private String dataRowState;
	
	@Override
	public PatientModelProto.PublicInsurance toProto() {

		PatientModelProto.PublicInsurance.Builder builder = PatientModelProto.PublicInsurance.newBuilder();
		builder.setStartDate(startDate);
		builder.setBunho(org.apache.commons.lang3.StringUtils.leftPad(bunho, 9, "0"));
		builder.setSuname(suname);
		builder.setGubun1(gubun1);
		builder.setGubunName1(gubunName1);
		builder.setJohap(johap);
		builder.setJohapName(johapName);
		builder.setTel(tel);
		builder.setGaein(gaein);
		builder.setGaeinNo(gaeinNo);
		builder.setBoninGubun(boninGubun);
		builder.setBoninGubunName(boninGubunName);
		builder.setPiname(piname);
		builder.setLastCheckDate(lastCheckDate);
		builder.setEndDate(endDate);
		builder.setJohapGubun(johapGubun);
		builder.setOldGubun(oldGubun);
		builder.setRetrieveYn(retrieveYn);
		builder.setOldStartDate(oldStartDate);
		builder.setChuidukDate(chuidukDate);
		builder.setEndYn(endYn);
		
		return builder.build();
	}

	@Override
	public List<PublicInsurance> copyFromPatientInfo(PatientInfo pt) throws Exception{
		List<PublicInsurance> listPublicInsurance = new ArrayList<PublicInsurance>();
		List<HealthInsuranceInfo> healthInsList = pt.getHealthInsuranceInformation();
		List<HealthInsuranceInfo> healthInsDistinctList = new ArrayList<HealthInsuranceInfo>();
		if(!CollectionUtils.isEmpty(healthInsList)){
			for (HealthInsuranceInfo info : healthInsList) {
				if(!exitsInList(info, healthInsDistinctList) && info.getInsuranceProviderClass() != null){
					healthInsDistinctList.add(info);
				}
			}
			
			for (HealthInsuranceInfo info : healthInsDistinctList) {
				PublicInsurance ins = new PublicInsuranceImpl();
				String orgGubun = "XX".equals(info.getInsuranceProviderClass()) ? "" : info.getInsuranceProviderClass();
				String gubun1 = OrcaUtils.getInsurCodeByClassCode(orgGubun);
				String johap = (info.getInsuranceProviderNumber() == null || "9999".equals(info.getInsuranceProviderNumber())) ? "" : info.getInsuranceProviderNumber(); 
				String johapName = StringUtils.isEmpty(info.getInsuranceProviderWholeName()) ? "" : info.getInsuranceProviderWholeName(); 
				String boninGubun = "1".equals(info.getRelationToInsuredPerson()) ? "0" : "1";
				
				ins.setStartDate(info.getCertificateStartDate().replace("-", "/"));
				ins.setEndDate(info.getCertificateExpiredDate().replace("-", "/"));
				ins.setBunho(pt.getPatientId());
				ins.setSuname(pt.getWholeName());
				ins.setGubun1(gubun1);
				ins.setGubunName1("");
				ins.setJohap(johap);
				ins.setJohapName(johapName);
				ins.setTel("");
				ins.setGaein(info.getHealthInsuredPersonSymbol() != null ? info.getHealthInsuredPersonSymbol() : "");
				ins.setGaeinNo(info.getHealthInsuredPersonNumber() != null ? info.getHealthInsuredPersonNumber() : "");
				ins.setBoninGubun(boninGubun);
				ins.setBoninGubunName("");
				ins.setPiname(info.getHealthInsuredPersonWholeName() != null ? info.getHealthInsuredPersonWholeName() : "");
				ins.setLastCheckDate(info.getInsuranceCheckDate() != null ? info.getInsuranceCheckDate().replace("-", "/") : "");
				ins.setJohapGubun("");
				ins.setOldGubun("");
				ins.setRetrieveYn("N");
				ins.setOldStartDate("");
				ins.setChuidukDate(info.getInsuranceCheckDate() != null ? info.getInsuranceCheckDate().replace("-", "/") : "");
				ins.setEndYn("N");
				ins.setDataRowState("");
				
				listPublicInsurance.add(ins);
			}
		}
		
		return listPublicInsurance;
	}
	
	@Override
	public List<PublicInsurance> toModelList(Document doc, PatientInfoResponse patientInfoResponse) throws Exception {
		List<PublicInsurance> listPublicInsurance = new ArrayList<PublicInsurance>();
    	
    	String bunho = XPathAPI.selectSingleNodeAsString(doc, OrcaPath.BUNHO_PATH.getPath());
    	String suname = XPathAPI.selectSingleNodeAsString(doc, OrcaPath.SUNAME_PATH.getPath());
		
    	bunho = bunho == null ? "" : CommonUtils.formatMmlString(bunho);
		suname = suname == null ? "" : CommonUtils.formatMmlString(suname);
		
    	// get all Health Insurance Module
    	List<Node> healthInsModules = XPathAPI.selectListOfNodes(doc, OrcaPath.HEALTH_INSURANCE_MODULE_PATH.getPath());
    	for (Node healthInsNode : healthInsModules) {
    		Document healthDoc = XPathAPI.node2Document(healthInsNode);
			HashMap<String, String> nsp = new HashMap<String, String>();
			nsp.put("mmlHi", "http://www.medxml.net/MML/ContentModule/HealthInsurance/1.1");
			
			String startDate = XPathAPI.selectSingleNodeAsString(healthDoc, OrcaPath.HEALTH_INSURANCE_ITEM_STARD_DATE_PATH.getPath(), nsp);
			String endDate = XPathAPI.selectSingleNodeAsString(healthDoc, OrcaPath.HEALTH_INSURANCE_ITEM_END_DATE_PATH.getPath(), nsp);
			String gubun1 = XPathAPI.selectSingleNodeAsString(healthDoc, OrcaPath.HEALTH_INSURANCE_ITEM_GUBUN1_PATH.getPath(), nsp);
			String gubunName1 = XPathAPI.selectSingleNodeAsString(healthDoc, OrcaPath.HEALTH_INSURANCE_ITEM_GUBUN_NAME1_PATH.getPath(), nsp);
			String johap = XPathAPI.selectSingleNodeAsString(healthDoc, OrcaPath.HEALTH_INSURANCE_JOHAP_PATH.getPath(), nsp);
			
			startDate = startDate == null ? "" : CommonUtils.formatMmlString(startDate);
			startDate = startDate.replace("-", "/");
			
			endDate = endDate == null ? "" : CommonUtils.formatMmlString(endDate);
			endDate = endDate.replaceAll("-", "/"); 
			
			gubun1 = gubun1 == null ? "" : CommonUtils.formatMmlString(gubun1);
			gubunName1 = gubunName1 == null ? "" : gubunName1.trim();
			johap = johap == null  ? "" : CommonUtils.formatMmlString(johap);

			if(!("9999".equals(johap) && OrcaPath.GUBUN_DEFAULT.getPath().equals(gubun1))){
				PublicInsurance boheom = new PublicInsuranceImpl();

				boheom.setStartDate(startDate);
				boheom.setBunho(bunho);
				boheom.setSuname(suname);
				if(gubun1.equals(OrcaPath.GUBUN_DEFAULT.getPath()))
				{
					gubun1 = "";
				}
				boheom.setGubun1(gubun1);
				boheom.setGubunName1(gubunName1);
				if(johap.equals(OrcaPath.INSURANCE_NUMBER_DEFAULT.getPath()))
				{
					johap = "";
				}
				boheom.setJohap(johap);
				boheom.setJohapName("");
				boheom.setTel("");
				boheom.setGaein("");
				boheom.setGaeinNo("");
				boheom.setBoninGubun("");
				boheom.setBoninGubunName("");
				boheom.setPiname("");
				boheom.setLastCheckDate("");
				boheom.setEndDate(endDate);
				boheom.setJohapGubun("");
				boheom.setOldGubun("");
				boheom.setRetrieveYn("N");
				boheom.setOldStartDate("");
				boheom.setChuidukDate("");
				boheom.setEndYn("N");

				if(!isExitsBoheomInList(listPublicInsurance, boheom)){
					listPublicInsurance.add(boheom);
				}
			}
    	}
    	
    	// get additional info from orca api
    	if(patientInfoResponse != null && patientInfoResponse.getPatientInformation() != null && patientInfoResponse.getPatientInformation().getHealthInsuranceInformation() != null){
            List<HealthInsuranceInfo> listHealthInsurance = patientInfoResponse.getPatientInformation().getHealthInsuranceInformation();
            for (PublicInsurance boheom : listPublicInsurance) {
                for (HealthInsuranceInfo healthInsInfo : listHealthInsurance) {
                    if(boheom.getJohap().equals(healthInsInfo.getInsuranceProviderNumber())){
                        String boninGubun = healthInsInfo.getRelationToInsuredPerson();

						/*
						 * In ORCA: 1 = 本人, 2 = 家族
						 * In KCCK: 0 = 本人, 1 = 家族
						 * */
                        if(!StringUtils.isEmpty(boninGubun)){
                            if(boninGubun.equals("1")){
                                boninGubun = "0";
                            } else if(boninGubun.equals("2")){
                                boninGubun = "1";
                            }
                        }

                        String gaein = healthInsInfo.getHealthInsuredPersonSymbol();
                        String gaeinNo = healthInsInfo.getHealthInsuredPersonNumber();
                        String chuidukDate = healthInsInfo.getInsuranceCheckDate();
                        String piname = healthInsInfo.getHealthInsuredPersonWholeName();
                        String lastCheckDate = healthInsInfo.getCertificateStartDate();

                        boninGubun = boninGubun == null ? "" : boninGubun;
                        gaein = gaein == null ? "" : gaein;
                        gaeinNo = gaeinNo == null ? "" : gaeinNo;
                        chuidukDate = chuidukDate == null ? "" : chuidukDate.replace("-", "/");
                        piname = piname == null ? "" : piname;
                        lastCheckDate = lastCheckDate == null ? "" : lastCheckDate.replace("-", "/");

                        boheom.setBoninGubun(boninGubun);
                        boheom.setGaein(gaein);
                        boheom.setGaeinNo(gaeinNo);
                        boheom.setChuidukDate(chuidukDate);
                        boheom.setPiname(piname);
                        boheom.setLastCheckDate(lastCheckDate);
                    }
                }
            }
        }
    	
    	return listPublicInsurance;
	}
	
	private boolean isExitsBoheomInList(List<PublicInsurance> listBoheom, PublicInsurance boheom){
    	boolean isExits = false;
    	for (PublicInsurance item : listBoheom) {
			if (item.getBunho().equals(boheom.getBunho()) && item.getJohap().equals(boheom.getJohap())
					&& item.getGubun1().equals(boheom.getGubun1())) {
				isExits = true;
				break;
			}
		}
    	
    	return isExits;
    }
	
	private boolean exitsInList(HealthInsuranceInfo info, List<HealthInsuranceInfo> healthInsList){
		boolean isExits = false;
		String infoGubun = info.getInsuranceProviderClass() != null ? info.getInsuranceProviderClass() : "";
		String infoJohap = info.getInsuranceProviderNumber() != null ? info.getInsuranceProviderNumber() : ""; 
		
		for (HealthInsuranceInfo item : healthInsList) {
			String tmpGubun = item.getInsuranceProviderClass() != null ? item.getInsuranceProviderClass() : "";
			String tmpJohap = item.getInsuranceProviderNumber() != null ? item.getInsuranceProviderNumber() : "";
			
			if(infoGubun.equals(tmpGubun) && infoJohap.equals(tmpJohap)){
				isExits = true;
				break;
			}
		}
		
		return isExits;
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
	public String getSuname() {
		return suname;
	}

	@Override
	public void setSuname(String suname) {
		this.suname = suname;
	}

	@Override
	public String getGubun1() {
		return gubun1;
	}

	@Override
	public void setGubun1(String gubun1) {
		this.gubun1 = gubun1;
	}

	@Override
	public String getGubunName1() {
		return gubunName1;
	}

	@Override
	public void setGubunName1(String gubunName1) {
		this.gubunName1 = gubunName1;
	}

	@Override
	public String getJohap() {
		return johap;
	}

	@Override
	public void setJohap(String johap) {
		this.johap = johap;
	}

	@Override
	public String getJohapName() {
		return johapName;
	}

	@Override
	public void setJohapName(String johapName) {
		this.johapName = johapName;
	}

	@Override
	public String getTel() {
		return tel;
	}

	@Override
	public void setTel(String tel) {
		this.tel = tel;
	}

	@Override
	public String getGaein() {
		return gaein;
	}

	@Override
	public void setGaein(String gaein) {
		this.gaein = gaein;
	}

	@Override
	public String getGaeinNo() {
		return gaeinNo;
	}

	@Override
	public void setGaeinNo(String gaeinNo) {
		this.gaeinNo = gaeinNo;
	}

	@Override
	public String getBoninGubun() {
		return boninGubun;
	}

	@Override
	public void setBoninGubun(String boninGubun) {
		this.boninGubun = boninGubun;
	}

	@Override
	public String getBoninGubunName() {
		return boninGubunName;
	}

	@Override
	public void setBoninGubunName(String boninGubunName) {
		this.boninGubunName = boninGubunName;
	}

	@Override
	public String getPiname() {
		return piname;
	}

	@Override
	public void setPiname(String piname) {
		this.piname = piname;
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
	public String getEndDate() {
		return endDate;
	}

	@Override
	public void setEndDate(String endDate) {
		this.endDate = endDate;
	}

	@Override
	public String getJohapGubun() {
		return johapGubun;
	}

	@Override
	public void setJohapGubun(String johapGubun) {
		this.johapGubun = johapGubun;
	}

	@Override
	public String getOldGubun() {
		return oldGubun;
	}

	@Override
	public void setOldGubun(String oldGubun) {
		this.oldGubun = oldGubun;
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
	public String getChuidukDate() {
		return chuidukDate;
	}

	@Override
	public void setChuidukDate(String chuidukDate) {
		this.chuidukDate = chuidukDate;
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
	
}
