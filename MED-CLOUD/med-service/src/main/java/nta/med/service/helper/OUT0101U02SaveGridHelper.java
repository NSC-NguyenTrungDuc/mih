//
//package nta.med.service.helper;
//
//import java.util.ArrayList;
//import java.util.List;
//
//import org.springframework.util.CollectionUtils;
//
//import nta.med.core.enums.OrcaApiConfig;
//import nta.med.core.utils.OrcaUtils;
//import nta.med.orca.gw.api.contracts.message.BaseNode;
//import nta.med.orca.gw.api.contracts.message.HealthInsuranceInfoMod;
//import nta.med.orca.gw.api.contracts.message.HomeAddressInformation;
//import nta.med.orca.gw.api.contracts.message.PatientModReq;
//import nta.med.orca.gw.api.contracts.message.PublicInsuranceInfoChild;
//import nta.med.orca.gw.api.contracts.message.PublicInsuranceInformationMod;
//import nta.med.orca.gw.api.contracts.message.WorkPlaceInformation;
//import nta.med.orca.gw.api.contracts.service.PatientModRequest;
//import nta.med.service.ihis.proto.NuroModelProto;
//
//public class OUT0101U02SaveGridHelper {
//
//	public static PatientModRequest patientInfoToRequest(NuroModelProto.NuroOUT0101U02GridPatientInfo info){
//		PatientModRequest patientModRequest = new PatientModRequest();
//		PatientModReq patientMod = new PatientModReq();
//		patientMod.setModKey(new BaseNode("2"));
//		patientMod.setPatientID(new BaseNode(info.getBunho()));
//		patientMod.setWholeName(new BaseNode(info.getSuname()));
//		patientMod.setWholeNameInKana(new BaseNode(info.getSuname2()));
//		patientMod.setBirthDate(new BaseNode(info.getBirth().replace("/", "-")));
//		String sex = info.getSex().equals("M") ? "1" : "2";
//		patientMod.setSex(new BaseNode(sex));
//		
//		String phoneNumber1 = "";
//		String phoneNumber2 = "";
//		String phoneNumber = "";		
//		
//		//
//		switch (info.getTelType()) {
//		case "1":
//			phoneNumber1 = info.getTel();
//			break;
//		case "2":
//			phoneNumber = info.getTel();
//			break;
//		case "3":
//			break;
//		case "4":
//			break;
//		case "5":
//			phoneNumber2 = info.getTel();
//			break;
//		default:
//			break;
//		}
//		
//		//
//		switch (info.getTelType2()) {
//		case "1":
//			phoneNumber1 = info.getTel1();
//			break;
//		case "2":
//			phoneNumber = info.getTel1();
//			break;
//		case "3":
//			break;
//		case "4":
//			break;
//		case "5":
//			phoneNumber2 = info.getTel1();
//			break;
//		default:
//			break;
//		}
//		
//		//
//		switch (info.getTelType3()) {
//		case "1":
//			phoneNumber1 = info.getTelHp();
//			break;
//		case "2":
//			phoneNumber = info.getTelHp();
//			break;
//		case "3":
//			break;
//		case "4":
//			break;
//		case "5":
//			phoneNumber2 = info.getTelHp();
//			break;
//		default:
//			break;
//		}
//		
//		HomeAddressInformation homeAddressInformation = new HomeAddressInformation();
//		homeAddressInformation.setAddressZipCode(new BaseNode(info.getZipCode1() + info.getZipCode2()));
//		homeAddressInformation.setWholeAddress1(new BaseNode(info.getAddress1()));
//		homeAddressInformation.setWholeAddress2(new BaseNode(info.getAddress2()));
//		homeAddressInformation.setPhoneNumber1(new BaseNode(phoneNumber1));
//		homeAddressInformation.setPhoneNumber2(new BaseNode(phoneNumber2));
//		homeAddressInformation.setType(OrcaApiConfig.ELEMENT_TYPE_RECORD.getValue());
//		patientMod.setHomeAddressInformation(homeAddressInformation);
//		
//		WorkPlaceInformation workPlaceInformation = new WorkPlaceInformation();
//		workPlaceInformation.setType(OrcaApiConfig.ELEMENT_TYPE_RECORD.getValue());
//		workPlaceInformation.setPhoneNumber(new BaseNode(phoneNumber));
//		patientMod.setWorkPlaceInformation(workPlaceInformation);
//		
//		patientMod.setType(OrcaApiConfig.ELEMENT_TYPE_RECORD.getValue());
//		patientModRequest.setPatientModReq(patientMod);
//		return patientModRequest;
//	}
//
//	public static PatientModRequest patientInfoAndBoheomInfoToRequest(NuroModelProto.NuroOUT0101U02GridBoheomInfo info, NuroModelProto.NuroOUT0101U02GridPatientInfo patientInfo){
//		PatientModRequest patientModRequest = patientInfoToRequest(patientInfo);
//		PatientModReq patientModReq = patientModRequest.getPatientModReq();
//		
//		HealthInsuranceInfoMod healthInsuranceInformation = new HealthInsuranceInfoMod();
//		healthInsuranceInformation.setType(OrcaApiConfig.ELEMENT_TYPE_RECORD.getValue());
//		healthInsuranceInformation.setInsuranceProviderClass(new BaseNode(OrcaUtils.getClassCodeByInsurCode(info.getGubun1())));
//		healthInsuranceInformation.setInsuranceProviderNumber(new BaseNode(info.getJohap()));
//		healthInsuranceInformation.setHealthInsuredPersonSymbol(new BaseNode(info.getGaein()));
//		healthInsuranceInformation.setHealthInsuredPersonNumber(new BaseNode(info.getGaeinNo()));
//		healthInsuranceInformation.setCertificateStartDate(new BaseNode(info.getStartDate().replace("/", "-")));
//		healthInsuranceInformation.setCertificateExpiredDate(new BaseNode(info.getEndDate().replace("/", "-")));
//		
//		String relationToInsuredPerson = "";
//		if("00".equals(info.getBoninGubun())){
//			relationToInsuredPerson = "1";
//		} else if("01".equals(info.getBoninGubun())){
//			relationToInsuredPerson = "2";
//		} 
//		
//		healthInsuranceInformation.setRelationToInsuredPerson(new BaseNode(relationToInsuredPerson));
//		
//		patientModReq.setHealthInsuranceInfoMod(healthInsuranceInformation);
//		patientModRequest.setPatientModReq(patientModReq);
//		
//		return patientModRequest;
//	}
//	
//	public static PatientModRequest patientInfoAndGongbiListToRequest(NuroModelProto.NuroOUT0101U02GridPatientInfo patientInfo, List<NuroModelProto.NuroOUT0101U02GridGongbiListInfo> gongbiSaveList){
//		PatientModRequest patientModRequest = patientInfoToRequest(patientInfo);
//		PatientModReq patientModReq = patientModRequest.getPatientModReq();
//		HealthInsuranceInfoMod healthInsuranceInformation = new HealthInsuranceInfoMod();
//		List<PublicInsuranceInfoChild> publicInsuranceInformation = new ArrayList<PublicInsuranceInfoChild>();
//		PublicInsuranceInformationMod publicInsuranceInformationMod = new PublicInsuranceInformationMod(); 
//		
//		for (NuroModelProto.NuroOUT0101U02GridGongbiListInfo info : gongbiSaveList) {
//			PublicInsuranceInfoChild publicIns = new PublicInsuranceInfoChild();
//			publicIns.setType(OrcaApiConfig.ELEMENT_TYPE_RECORD.getValue());
//			publicIns.setPublicInsuranceClass(new BaseNode(info.getGongbiCode()));
//			publicIns.setPublicInsuranceName(new BaseNode(""));
//			publicIns.setPublicInsurerNumber(new BaseNode(info.getSugubjaBunho()));
//			publicIns.setPublicInsuredPersonNumber(new BaseNode(""));
//			publicIns.setCertificateIssuedDate(new BaseNode(info.getEndDate().replace("/", "-")));
//			publicInsuranceInformation.add(publicIns);
//		}
//		
//		publicInsuranceInformationMod.setType(OrcaApiConfig.ELEMENT_TYPE_ARRAY.getValue());
//		publicInsuranceInformationMod.setPublicInsList(publicInsuranceInformation);
//		
//		healthInsuranceInformation.setType(OrcaApiConfig.ELEMENT_TYPE_RECORD.getValue());
//		healthInsuranceInformation.setPublicInsuranceInformation(publicInsuranceInformationMod);
//		
//		patientModReq.setHealthInsuranceInfoMod(healthInsuranceInformation);
//		patientModRequest.setPatientModReq(patientModReq);
//		return patientModRequest;
//	}
//	
//	public static List<PatientModRequest> patientInfoAndBoheomAndGongbiToRequest(NuroModelProto.NuroOUT0101U02GridPatientInfo patientInfo, 
//			List<NuroModelProto.NuroOUT0101U02GridBoheomInfo> boheomSaveList, 
//			List<NuroModelProto.NuroOUT0101U02GridGongbiListInfo> gongbiSaveList){
//		
//		List<PatientModRequest> patientModRequestList = new ArrayList<PatientModRequest>();
//		
//		for (NuroModelProto.NuroOUT0101U02GridBoheomInfo info : boheomSaveList) {
//			patientModRequestList.add(patientInfoAndBoheomInfoToRequest(info, patientInfo));
//		}
//		
//		List<PublicInsuranceInfoChild> publicInsuranceInformation = new ArrayList<PublicInsuranceInfoChild>();
//		PublicInsuranceInformationMod publicInsuranceInformationMod = new PublicInsuranceInformationMod();
//		for (NuroModelProto.NuroOUT0101U02GridGongbiListInfo info : gongbiSaveList) {
//			PublicInsuranceInfoChild publicIns = new PublicInsuranceInfoChild();
//			publicIns.setType(OrcaApiConfig.ELEMENT_TYPE_RECORD.getValue());
//			publicIns.setPublicInsuranceClass(new BaseNode(info.getGongbiCode()));
//			publicIns.setPublicInsuranceName(new BaseNode(""));
//			publicIns.setPublicInsurerNumber(new BaseNode(info.getSugubjaBunho()));
//			publicIns.setPublicInsuredPersonNumber(new BaseNode(""));
//			publicIns.setCertificateIssuedDate(new BaseNode(info.getEndDate().replace("/", "-")));
//			publicInsuranceInformation.add(publicIns);
//		}
//		
//		publicInsuranceInformationMod.setType(OrcaApiConfig.ELEMENT_TYPE_ARRAY.getValue());
//		publicInsuranceInformationMod.setPublicInsList(publicInsuranceInformation);
//		
//		patientModRequestList.get(0).getPatientModReq().getHealthInsuranceInfoMod().setPublicInsuranceInformation(publicInsuranceInformationMod);
//		
//		return patientModRequestList;
//	}
//		
//	public static PatientModRequest patientInfoAndBoheomAndGongbiToOrcaRequest(NuroModelProto.NuroOUT0101U02GridPatientInfo patientInfo, 
//			List<NuroModelProto.NuroOUT0101U02GridBoheomInfo> boheomSaveList, 
//			List<NuroModelProto.NuroOUT0101U02GridGongbiListInfo> gongbiSaveList){
//		
//		PatientModRequest patientModRequest = null;
//		
//		// Case 1: Sync patient info only
//		if(CollectionUtils.isEmpty(boheomSaveList) && CollectionUtils.isEmpty(gongbiSaveList)){
//			patientModRequest = patientInfoToRequest(patientInfo);
//		}
//		
//		// Case 2: Sync patient info + 1 private ins 
//		if(!CollectionUtils.isEmpty(boheomSaveList) && CollectionUtils.isEmpty(gongbiSaveList)){
//			patientModRequest = patientInfoAndBoheomInfoToRequest(boheomSaveList.get(0), patientInfo);
//		}
//		
//		// Case 3: Sync patient info + 1 private ins + n public ins 
//		if(!CollectionUtils.isEmpty(boheomSaveList) && !CollectionUtils.isEmpty(gongbiSaveList)){
//			patientModRequest = patientInfoAndBoheomInfoToRequest(boheomSaveList.get(0), patientInfo);
//			
//			List<PublicInsuranceInfoChild> publicInsuranceInformation = new ArrayList<PublicInsuranceInfoChild>();
//			PublicInsuranceInformationMod publicInsuranceInformationMod = new PublicInsuranceInformationMod();
//			for (NuroModelProto.NuroOUT0101U02GridGongbiListInfo info : gongbiSaveList) {
//				PublicInsuranceInfoChild publicIns = new PublicInsuranceInfoChild();
//				publicIns.setType(OrcaApiConfig.ELEMENT_TYPE_RECORD.getValue());
//				publicIns.setPublicInsuranceClass(new BaseNode(info.getGongbiCode()));
//				publicIns.setPublicInsuranceName(new BaseNode(""));
//				publicIns.setPublicInsurerNumber(new BaseNode(info.getSugubjaBunho()));
//				publicIns.setPublicInsuredPersonNumber(new BaseNode(""));
//				publicIns.setCertificateIssuedDate(new BaseNode(info.getStartDate().replace("/", "-")));
//				publicIns.setCertificateExpiredDate(new BaseNode(info.getEndDate().replace("/", "-")));
//				publicInsuranceInformation.add(publicIns);
//			}
//			
//			publicInsuranceInformationMod.setType(OrcaApiConfig.ELEMENT_TYPE_ARRAY.getValue());
//			publicInsuranceInformationMod.setPublicInsList(publicInsuranceInformation);
//			patientModRequest.getPatientModReq().getHealthInsuranceInfoMod().setPublicInsuranceInformation(publicInsuranceInformationMod);
//		}
//		
//		return patientModRequest; 
//	}
//}
//
