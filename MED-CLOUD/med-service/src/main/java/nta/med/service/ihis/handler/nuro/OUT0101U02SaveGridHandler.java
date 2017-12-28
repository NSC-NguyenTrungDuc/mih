package nta.med.service.ihis.handler.nuro;

import static nta.med.common.remoting.rpc.message.RpcMessageFormatter.format;

import java.util.ArrayList;
import java.util.Date;
import java.util.HashSet;
import java.util.List;
import java.util.Set;
import java.util.concurrent.TimeUnit;

import javax.annotation.Resource;

import org.apache.commons.lang.RandomStringUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.common.remoting.rpc.message.RpcMessageParser;
import nta.med.common.util.concurrent.future.FutureEx;
import nta.med.core.common.annotation.Route;
import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.bas.Bas0001;
import nta.med.core.domain.bas.Bas0102;
import nta.med.core.domain.out.Out0101;
import nta.med.core.domain.out.Out0102;
import nta.med.core.domain.out.Out0105;
import nta.med.core.glossary.AccountingConfig;
import nta.med.core.glossary.DataRowState;
import nta.med.core.glossary.InOutType;
import nta.med.core.glossary.Language;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.data.dao.medi.bas.Bas0212Repository;
import nta.med.data.dao.medi.ifs.Ifs0003Repository;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.data.dao.medi.out.Out0102Repository;
import nta.med.data.dao.medi.out.Out0105Repository;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.NuroServiceProto.OUT0101U02SaveGridRequest;
import nta.med.service.ihis.proto.NuroServiceProto.OUT0101U02SaveGridResponse;

@Service
@Scope("prototype")
public class OUT0101U02SaveGridHandler extends ScreenHandler<NuroServiceProto.OUT0101U02SaveGridRequest, NuroServiceProto.OUT0101U02SaveGridResponse>{
	
	private static final Log LOGGER = LogFactory.getLog(OUT0101U02SaveGridHandler.class);

	private RpcMessageParser parser = new RpcMessageParser(NuroServiceProto.class);
	
	@Resource
	private Out0101Repository out0101Repository;
	
	@Resource
	private Out0102Repository out0102Repository;
	
	@Resource
	private Out0105Repository out0105Repository;
	
	@Resource
	private CommonRepository commonRepository;
	
	@Resource
	private Bas0212Repository bas0212Repository;
	
	@Resource
	private Bas0102Repository bas0102Repository;
	
	@Resource
	private Ifs0003Repository ifs0003Repository;	
	
	@Resource
	Bas0001Repository bas0001Repository;

	public OUT0101U02SaveGridHandler() {
	}

	@Override
	@Route(global = true)
	@Transactional(readOnly = true)
	public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, OUT0101U02SaveGridRequest request) throws Exception  {
		String orcaRequest = request.getOrcaRequest();
		boolean isOrcaRequest = orcaRequest != null && orcaRequest.equalsIgnoreCase("true");
		if(isOrcaRequest){
			List<Bas0001> bas0001List = bas0001Repository.findLatestByHospCode(request.getHospCode());
			LOGGER.info("OUT0101U02SaveGridHandler preHandle has session Id" +sessionId);
			if(!CollectionUtils.isEmpty(bas0001List)){
				setSessionInfo(vertx, sessionId,
						SessionUserInfo.setSessionUserInfoByUserGroup(bas0001List.get(0).getHospCode(), bas0001List.get(0).getLanguage(), "", 1, ""));
				LOGGER.info("OUT0101U02SaveGridHandler preHandle has hosp code" + bas0001List.get(0).getHospCode());
			}else{
				LOGGER.info("OUT0101U02SaveGridHandler preHandle not found hosp code");
			}
		}
	}

	@Override
	@Transactional
	@Route(global = false)		
	public  OUT0101U02SaveGridResponse handle(Vertx vertx, String clientId,
											  String sessionId, long contextId, OUT0101U02SaveGridRequest request) throws Exception  {

		NuroServiceProto.OUT0101U02SaveGridResponse.Builder response = NuroServiceProto.OUT0101U02SaveGridResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		LOGGER.info("OUT0101U02SaveGridHandler session Id is : "+ sessionId);
		LOGGER.info("OUT0101U02SaveGridHandler hospCode is : "+ hospCode);
		
		String orcaRequest = request.getOrcaRequest();
		boolean isOrcaRequest = orcaRequest != null && orcaRequest.equalsIgnoreCase("true");
		boolean result = false;
		StringBuilder refPwd = new StringBuilder();
		
		if(isOrcaRequest){
			result = executeOrca(request, response, hospCode, language, refPwd);
			response.setResult(result);
			if(!result) throw new ExecutionException(response.build());
			return response.build();
		}
				
		List<NuroModelProto.NuroOUT0101U02GridPatientInfo> patientList = request.getPatientListList();
		List<Bas0102> bas0102List = bas0102Repository.findByHospCodeAndCodeType(hospCode, AccountingConfig.ACCT_TYPE.getValue());
		boolean useExtAccounting = !CollectionUtils.isEmpty(bas0102List) && AccountingConfig.ACCCT_TYPE_ORCA.getValue().equalsIgnoreCase(bas0102List.get(0).getCode());
		
		if(!useExtAccounting){
			result = execute(request, response, hospCode, language, refPwd);
			response.setResult(result);
			if(!result) throw new ExecutionException(response.build());
			
			response.setRefPwd(refPwd == null ? "" : refPwd.toString());
			return response.build();
		}
		
		boolean isMod1 = false;
		boolean isMod2 = false;
		String modKey = "2";
		String extPatientCode = patientList.get(0).getBunho();
		
		NuroModelProto.NuroOUT0101U02GridPatientInfo patientUpdate = patientList.get(0);
		NuroModelProto.NuroOUT0101U02GridPatientInfo patientUpdateMod1 = patientList.get(0);
		NuroModelProto.NuroOUT0101U02GridPatientInfo patientUpdateMod2 = patientList.get(0);
		Out0101 patientBeforeUpdate = null;
		
		if(!InOutType.IN.getValue().equalsIgnoreCase(patientList.get(0).getIuGubun())){
			List<Out0101> patientListBeforeUpdate = out0101Repository.getByBunho(hospCode, patientList.get(0).getBunho());
			
			if(!CollectionUtils.isEmpty(patientListBeforeUpdate)){
				patientBeforeUpdate = patientListBeforeUpdate.get(0);
				if (!patientUpdate.getSuname().equals(patientBeforeUpdate.getSuname())
						|| !patientUpdate.getSuname2().equals(patientBeforeUpdate.getSuname2())) {
					isMod1 = true;
				}
				
				if(!patientUpdate.getSex().equals(patientBeforeUpdate.getSex()) 
						|| !patientUpdate.getBirth().equals(DateUtil.toString(patientBeforeUpdate.getBirth(), DateUtil.PATTERN_YYMMDD))){
					isMod2 = true;
				}
				
			}
		}
		
		// #1
		if(!isMod1 && !isMod2){
			NuroServiceProto.CreatePatientRequest.Builder builder = NuroServiceProto.CreatePatientRequest.newBuilder()
					.setId(System.currentTimeMillis())
					.setHospCode(hospCode)
					.setModKey(modKey)
					.setPatientProfile(patientUpdateMod1)
					.addAllPrivateInsurance(request.getGongbiListList())
					.addAllPublicInsurance(request.getBoheomListList());

			FutureEx<NuroServiceProto.CreatePatientResponse> res = send(vertx, parser, builder.build(), hospCode);
			NuroServiceProto.CreatePatientResponse r = res.get(30, TimeUnit.SECONDS);
			if(r != null) {
				LOGGER.info("response from remote gateway: " + format(r));
				if(r.hasNewPatientCode()) response.setNewPatientCode(r.getNewPatientCode());
				if(r.hasMessageCode()) response.setErrCode(r.getMessageCode());
				result = r.getResult() == NuroServiceProto.CreatePatientResponse.Result.SUCCESS;
				if(r.hasNewPatientCode()) extPatientCode = r.getNewPatientCode(); 
			}
		}
		
		if(isMod1 && isMod2){
			patientUpdateMod1 = patientUpdate.toBuilder()
					.setSex(patientBeforeUpdate.getSex())
					.setBirth(DateUtil.toString(patientBeforeUpdate.getBirth(), DateUtil.PATTERN_YYMMDD))
					.build();
		}
		
		// #2
		if(isMod1){
			modKey = "1";
			NuroServiceProto.CreatePatientRequest.Builder builder = NuroServiceProto.CreatePatientRequest.newBuilder()
					.setId(System.currentTimeMillis())
					.setHospCode(hospCode)
					.setModKey(modKey)
					.setPatientProfile(patientUpdateMod1)
					.addAllPrivateInsurance(request.getGongbiListList())
					.addAllPublicInsurance(request.getBoheomListList());

			FutureEx<NuroServiceProto.CreatePatientResponse> res = send(vertx, parser, builder.build(), hospCode);
			NuroServiceProto.CreatePatientResponse r = res.get(30, TimeUnit.SECONDS);
			if(r != null) {
				LOGGER.info("response from remote gateway: " + format(r));
				if(r.hasNewPatientCode()) response.setNewPatientCode(r.getNewPatientCode());
				if(r.hasMessageCode()) response.setErrCode(r.getMessageCode());
				result = r.getResult() == NuroServiceProto.CreatePatientResponse.Result.SUCCESS;
				if(r.hasNewPatientCode()) extPatientCode = r.getNewPatientCode();
			}
		}
		
		// #3
		if(isMod2){
			modKey = "2";
			patientUpdateMod2 = patientUpdate.toBuilder()
					.setSex(patientList.get(0).getSex())
					.setBirth(patientList.get(0).getBirth())
					.build();
			
			NuroServiceProto.CreatePatientRequest.Builder builder2 = NuroServiceProto.CreatePatientRequest.newBuilder()
					.setId(System.currentTimeMillis())
					.setHospCode(hospCode)
					.setModKey(modKey)
					.setPatientProfile(patientUpdateMod2)
					.addAllPrivateInsurance(request.getGongbiListList())
					.addAllPublicInsurance(request.getBoheomListList());

			FutureEx<NuroServiceProto.CreatePatientResponse> res2 = send(vertx, parser, builder2.build(), hospCode);
			NuroServiceProto.CreatePatientResponse r2 = res2.get(30, TimeUnit.SECONDS);
			if(r2 != null) {
				LOGGER.info("response from remote gateway: " + format(r2));
				if(r2.hasNewPatientCode()) response.setNewPatientCode(r2.getNewPatientCode());
				if(r2.hasMessageCode()) response.setErrCode(r2.getMessageCode());
				result = r2.getResult() == NuroServiceProto.CreatePatientResponse.Result.SUCCESS;
				if(r2.hasNewPatientCode()) extPatientCode = r2.getNewPatientCode();
			}
		}
		
		if(!result){
			LOGGER.warn("FAIL TO CRUD PATIENT TO ORCA: HOSP_CODE = " + hospCode + ", PATIENT_CODE = " + request.getPatientListList().get(0).getBunho());
			response.setResult(result);
			return response.build();
		}
		
		NuroServiceProto.OUT0101U02SaveGridRequest.Builder extRequest = NuroServiceProto.OUT0101U02SaveGridRequest.newBuilder();
		if(request.hasUserId()) extRequest.setUserId(request.getUserId());
		if(request.hasPatientCode() && !request.getPatientCode().contains("*")) extRequest.setPatientCode(request.getPatientCode());
		if(request.hasHospCode()) extRequest.setHospCode(request.getHospCode());
		if(request.hasAutoBunhoFlg()) extRequest.setAutoBunhoFlg(request.getAutoBunhoFlg());
		if(request.hasOrcaRequest()) extRequest.setOrcaRequest(request.getOrcaRequest());
		if(request.hasOrcaGigwanCode()) extRequest.setOrcaGigwanCode(request.getOrcaGigwanCode());
		
		NuroModelProto.NuroOUT0101U02GridPatientInfo.Builder ptInfo = NuroModelProto.NuroOUT0101U02GridPatientInfo.newBuilder();
		BeanUtils.copyProperties(request.getPatientListList().get(0), ptInfo, language);
		ptInfo.setBunho(extPatientCode);
		extRequest.addPatientList(ptInfo);
		
		if(!CollectionUtils.isEmpty(request.getBoheomListList())) {
			for(NuroModelProto.NuroOUT0101U02GridBoheomInfo info : request.getBoheomListList()) {
				extRequest.addBoheomList(info.toBuilder().setBunho(extPatientCode));
			}
		}
		
		if(!CollectionUtils.isEmpty(request.getGongbiListList())) {
			for (NuroModelProto.NuroOUT0101U02GridGongbiListInfo info : request.getGongbiListList()) {
				extRequest.addGongbiList(info.toBuilder().setBunho(extPatientCode));
			}
		}
		
		boolean kcckResult = execute(extRequest.build(), response, hospCode, language, refPwd);
		response.setResult(kcckResult);
		if(!kcckResult) throw new ExecutionException(response.build());
		response.setRefPwd(refPwd == null ? "" : refPwd.toString());
		return response.build();
	}
	
	/**
	 * Case insert/update patient, insurance from ORCA
	 * Request from MED-GATEWAY
	 */
	private boolean executeOrca(NuroServiceProto.OUT0101U02SaveGridRequest request,
								NuroServiceProto.OUT0101U02SaveGridResponse.Builder response,
								String orcaHospCode,
								String language,
								StringBuilder refPwd) throws Exception{
		
		String userId = request.getUserId();
		List<NuroModelProto.NuroOUT0101U02GridPatientInfo> patientList = request.getPatientListList();
		List<NuroModelProto.NuroOUT0101U02GridBoheomInfo> boheomList = request.getBoheomListList();
		List<NuroModelProto.NuroOUT0101U02GridGongbiListInfo> gongbiList = request.getGongbiListList();

		if(CollectionUtils.isEmpty(patientList)){
			return false;
		}

		// OUT0101
		List<Out0101> ptList = saveOrcaPatientInfo(patientList, userId, orcaHospCode, true, response, language);
		refPwd.append(CollectionUtils.isEmpty(ptList) ? "" : ptList.get(0).getPwd());
		
		// OUT0102
		saveOrcaBoheomInfo(boheomList, userId, orcaHospCode);

		// OUT0105
		saveOrcaGongbiList(gongbiList, response, userId, orcaHospCode, language);

		return true;
	}

	/**
	 * Case - Insert/update patient, insurance from MISA/KCCK
	 * 		- Hospital do not use ORCA CLOUD
	 * Request from KCCK
	 */
	private boolean execute (NuroServiceProto.OUT0101U02SaveGridRequest request, 
							 NuroServiceProto.OUT0101U02SaveGridResponse.Builder response, 
							 String hospCode, String language, StringBuilder refPwd) throws Exception {
		
		// patient_list
		if(!savePatientList(request, response, hospCode, language, refPwd)){
			return false;
		}
		
		// boheom_list
		if(!saveBoheomList(request, hospCode)){
			return false;
		}

		// gongbi_list
		if(!saveGongbiList(request, hospCode)){
			return false;
		}
		
		return true;
	}
	
	private boolean savePatientList(NuroServiceProto.OUT0101U02SaveGridRequest request, 
									NuroServiceProto.OUT0101U02SaveGridResponse.Builder response, 
									String hospCode, String language, StringBuilder refPwd) throws Exception{
		
		String patientPwd = "";
		
		if(!CollectionUtils.isEmpty(request.getPatientListList())) {
			for (NuroModelProto.NuroOUT0101U02GridPatientInfo info : request.getPatientListList()) {
				String leftPadBunho = org.apache.commons.lang3.StringUtils.leftPad(info.getBunho(), 9, "0");
				String  nuroOUT0101U02CheckExistsX = out0101Repository.getNuroOUT0101U02CheckExistsX(hospCode, leftPadBunho);
				
				// In case sync patient form MISA
				if(StringUtils.isEmpty(info.getIuGubun())){
					String iuGubun = StringUtils.isEmpty(nuroOUT0101U02CheckExistsX) ? InOutType.IN.getValue() : "U";
					info = info.toBuilder()
							.setIuGubun(iuGubun)
							.setBunho(leftPadBunho)
							.build();		
				}
				
				if (InOutType.IN.getValue().equalsIgnoreCase(info.getIuGubun())) {
					if(!StringUtils.isEmpty(nuroOUT0101U02CheckExistsX)){
						response.setErrCode("2");
						return false;
					}else{
						Out0101 pt = insertPatient(info, request.getUserId(), hospCode, info.getBunho(), false, language);
						patientPwd = (pt == null || pt.getPwd() == null) ? "" : pt.getPwd();
					}
				} else {
					String result = out0101Repository.getNuroOUT0101U02CheckExistsY(hospCode, info.getBunho());
					if(StringUtils.isEmpty(result) || (!StringUtils.isEmpty(result) && !"Y".equals(result))){
						return false;
					}
					
					int rowUpdated = updatePatient(info, request.getUserId(), hospCode, response, language);
					if(rowUpdated <= 0){
						LOGGER.info("CAN NOT UPDATE PATIENT INFO");
						return false;
					}
				}
			}
		}
		
		refPwd.append(patientPwd);
		return true;
	}
	
	private boolean saveBoheomList(NuroServiceProto.OUT0101U02SaveGridRequest request, String hospCode){
		if(!CollectionUtils.isEmpty(request.getBoheomListList())) {
			for (NuroModelProto.NuroOUT0101U02GridBoheomInfo  info : request.getBoheomListList()) {
				if(DataRowState.ADDED.getValue().equalsIgnoreCase(info.getDataRowState())) {
					String  nuroOUT0101U02GetY = out0102Repository.getNuroOUT0101U02GetY(hospCode, info.getBunho(),
							info.getGubun1(), DateUtil.toDate(info.getStartDate(), DateUtil.PATTERN_YYMMDD));
					if(nuroOUT0101U02GetY != null && !nuroOUT0101U02GetY.isEmpty()){
						return false;
					}
					insertOut0102(info, request.getUserId(), hospCode);
				} else if(DataRowState.MODIFIED.getValue().equalsIgnoreCase(info.getDataRowState())) {
					String  nuroOUT0101U02GetY = out0102Repository.getNuroOUT0101U02GetY(hospCode, info.getBunho(),
							info.getGubun1(), DateUtil.toDate(info.getStartDate(), DateUtil.PATTERN_YYMMDD));
					if(nuroOUT0101U02GetY != null && !"Y".equalsIgnoreCase(nuroOUT0101U02GetY) ){
						return false;
					}
					Integer rs = updateOut0102(info, request.getUserId(), hospCode);
					if(rs <= 0) return false;
				} else if(DataRowState.DELETED.getValue().equalsIgnoreCase(info.getDataRowState())) {
					Date oldStartDate = DateUtil.toDate(info.getOldStartDate(), DateUtil.PATTERN_YYMMDD);
					Integer rs = out0102Repository.deleteNuroOUT0101U02DeleteBoheom(hospCode, info.getBunho(), info.getOldGubun(), oldStartDate);
					if(rs <= 0) return false;
				}

			}
		}
		
		return true;
	}
	
	private boolean saveGongbiList(NuroServiceProto.OUT0101U02SaveGridRequest request, String hospCode){
		if(!CollectionUtils.isEmpty(request.getGongbiListList())) {
			for (NuroModelProto.NuroOUT0101U02GridGongbiListInfo info : request.getGongbiListList()) {
				if(DataRowState.ADDED.getValue().equalsIgnoreCase(info.getDataRowState())) {
					String result = out0105Repository.getNuroOUT0101U02GongbiListGetY(hospCode, info.getGongbiCode(), info.getBunho(), DateUtil.toDate(info.getStartDate(), DateUtil.PATTERN_YYMMDD));
					if(result != null && !result.isEmpty()){
						return false;
					}
					
					insertOut0105(info, request.getUserId(), hospCode);
				} else if(DataRowState.MODIFIED.getValue().equalsIgnoreCase(info.getDataRowState())) {
					Integer resultUpdate = out0105Repository.updateNuroOUT0101U02Gongbi(request.getUserId(), new Date(),
							DateUtil.toDate(info.getStartDate(), DateUtil.PATTERN_YYMMDD), info.getBunho(), info.getBudamjaBunho(),
							info.getGongbiCode(), info.getSugubjaBunho(), DateUtil.toDate(info.getEndDate(), DateUtil.PATTERN_YYMMDD),
							info.getRemark(), DateUtil.toDate(info.getLastCheckDate(), DateUtil.PATTERN_YYMMDD), hospCode, info.getOldStartDate());
					LOGGER.info("updateNuroOUT0101U02Gongbi rs=" + resultUpdate);
					if(resultUpdate <= 0) {
						return false;
					}
				} else if(DataRowState.DELETED.getValue().equalsIgnoreCase(info.getDataRowState())) {
					Integer resultDelete = out0105Repository.deleteOut0105ByPatientCodeAndGongbiCode(hospCode, info.getStartDate(), info.getBunho(), info.getGongbiCode());
					LOGGER.info("deleteOut0105ByPatientCodeAndGongbiCode rs=" + resultDelete);
					if (resultDelete <= 0) return false;
				}
			}
		}
		
		return true;
	}
	
	private Out0101 insertPatient(NuroModelProto.NuroOUT0101U02GridPatientInfo info, 
			String userId, String hospCode, String bunho, boolean isOrca, String language) throws Exception{
		
		Out0101 out0101 = new Out0101();
		Date date = new Date();
		String suname2 = info.getSuname2();
		if(Language.JAPANESE.toString().equalsIgnoreCase(language)){
			suname2 = CommonUtils.convertToHalfWidthKana(suname2);
		}
		out0101.setSysDate(date);
		out0101.setSysId(userId);
		out0101.setUpdDate(date);
		out0101.setUpdId(userId);
		out0101.setHospCode(hospCode);
		out0101.setBunho(bunho);
		out0101.setSuname(info.getSuname());
		out0101.setSex(info.getSex());
		out0101.setBirth(DateUtil.toDate(info.getBirth(), DateUtil.PATTERN_YYMMDD));
		out0101.setZipCode1(info.getZipCode1());
		out0101.setZipCode2(info.getZipCode2());
		out0101.setAddress1(info.getAddress1());
		out0101.setAddress2(info.getAddress2());
		out0101.setTel(info.getTel());
		out0101.setTel1(info.getTel1());
		out0101.setGubun(info.getType());
		out0101.setTelHp(info.getTelHp());
		out0101.setEmail(info.getEmail());
		out0101.setSuname2(suname2);
		out0101.setTelGubun(info.getTelType());
		out0101.setTelGubun2(info.getTelType2());
		out0101.setTelGubun3(info.getTelType3());
		out0101.setDeleteYn(info.getDeleteYn());
		out0101.setPaceMakerYn(info.getPaceMakerYn());
		out0101.setSelfPaceMaker(info.getSelfPaceMaker());
		out0101.setBunhoType(info.getPatientType());
		out0101.setBunhoExt(info.getRefId());
		if(!StringUtils.isEmpty(info.getParentCode())){
			out0101.setParentCode(info.getParentCode());	
		}
		if(isOrca){
			String password = RandomStringUtils.randomAlphabetic(8);
			out0101.setPwd(password.toUpperCase());
		} else {
			out0101.setPwd(info.getPass().toUpperCase());
		}
		out0101.setBillingType(info.getBillingType());
		LOGGER.info(out0101.toString());
		out0101Repository.save(out0101);
		
		return out0101;
	}
	
	private Integer updatePatient(NuroModelProto.NuroOUT0101U02GridPatientInfo info, 
								  String userId, String hospCode, 
								  NuroServiceProto.OUT0101U02SaveGridResponse.Builder response, String language) throws Exception{
		String suname2 = info.getSuname2();
		if(Language.JAPANESE.toString().equalsIgnoreCase(language)){
			suname2 = CommonUtils.convertToHalfWidthKana(suname2);
		}
		if("C".equalsIgnoreCase(info.getSex()) && StringUtils.isEmpty(info.getBirth())){
			return out0101Repository.updateNuroOUT0101U02PatientCaseSexIsC(
					userId,
					info.getSuname(),
					info.getZipCode1(),
					info.getZipCode2(),
					info.getAddress1(),
					info.getAddress2(),
					info.getTel(),
					info.getTel1(),
					info.getType(),
					info.getTelHp(),
					info.getEmail(),
					suname2,
					info.getTelType(),
					info.getTelType2(),
					info.getTelType3(),
					info.getDeleteYn(),
					info.getPaceMakerYn(),
					info.getSelfPaceMaker(),
					info.getPatientType(),
					info.getRefId(),
					hospCode,
					info.getBunho(),
					info.getBillingType());
		}
		
		return out0101Repository.updateNuroOUT0101U02Patient(
				userId,
				info.getSuname(),
				info.getSex(),
				DateUtil.toDate(info.getBirth(), DateUtil.PATTERN_YYMMDD),
				info.getZipCode1(),
				info.getZipCode2(),
				info.getAddress1(),
				info.getAddress2(),
				info.getTel(),
				info.getTel1(),
				info.getType(),
				info.getTelHp(),
				info.getEmail(),
				suname2,
				info.getTelType(),
				info.getTelType2(),
				info.getTelType3(),
				info.getDeleteYn(),
				info.getPaceMakerYn(),
				info.getSelfPaceMaker(),
				info.getPatientType(),
				info.getRefId(),
				hospCode,
				info.getBunho(),
				info.getBillingType());
	}
	
	private void insertOut0102(NuroModelProto.NuroOUT0101U02GridBoheomInfo  info, String userId, String hospCode){
		Out0102 out0102 = new Out0102();
		out0102.setSysDate(new Date());
		if(!StringUtils.isEmpty(userId)){
			out0102.setSysId(userId);
		}
		out0102.setUpdDate(new Date());
		if(!StringUtils.isEmpty(userId)){
			out0102.setUpdId(userId);
		}
		if(!StringUtils.isEmpty(info.getStartDate())){
			out0102.setStartDate(DateUtil.toDate(info.getStartDate(),DateUtil.PATTERN_YYMMDD));
		}
		if(!StringUtils.isEmpty(info.getBunho())){
			out0102.setBunho(info.getBunho());
		}
		if(!StringUtils.isEmpty(info.getGubun1())){
			out0102.setGubun(info.getGubun1());
		}
		if(!StringUtils.isEmpty(info.getJohap())){
			out0102.setJohap(info.getJohap());
		}
		if(!StringUtils.isEmpty(info.getGaein())){
			out0102.setGaein(info.getGaein());
		}
		if(!StringUtils.isEmpty(info.getPiname())){
			out0102.setPiname(info.getPiname());
		}
		if(!StringUtils.isEmpty(info.getBoninGubun())){
			out0102.setBonGaGubun(info.getBoninGubun());
		}
		if(!StringUtils.isEmpty(info.getEndDate())){
			out0102.setEndDate(DateUtil.toDate(info.getEndDate(),DateUtil.PATTERN_YYMMDD));
		}
		else{
			out0102.setEndDate(DateUtil.toDate("9998/12/31", DateUtil.PATTERN_YYMMDD));
		}
		
		if(!StringUtils.isEmpty(info.getGaeinNo())){
			out0102.setGaeinNo(info.getGaeinNo());
		}
		if(!StringUtils.isEmpty(info.getLastCheckDate())){
			out0102.setLastCheckDate(DateUtil.toDate(info.getLastCheckDate(), DateUtil.PATTERN_YYMMDD));
		}
		if(!StringUtils.isEmpty(info.getChuidukDate())){
			out0102.setChuidukDate(DateUtil.toDate(info.getChuidukDate(),DateUtil.PATTERN_YYMMDD));
		}
		out0102.setHospCode(hospCode);
		LOGGER.info(out0102.toString());
		out0102Repository.save(out0102);
	}
	
	private void insertOut0102List(List<NuroModelProto.NuroOUT0101U02GridBoheomInfo> infoList, String userId, String hospCode){
		List<Out0102> out0102List = new ArrayList<>();
		
		for (NuroModelProto.NuroOUT0101U02GridBoheomInfo info : infoList) {
			Out0102 out0102 = new Out0102();
			out0102.setSysDate(new Date());
			if(!StringUtils.isEmpty(userId)){
				out0102.setSysId(userId);
			}
			out0102.setUpdDate(new Date());
			if(!StringUtils.isEmpty(userId)){
				out0102.setUpdId(userId);
			}
			if(!StringUtils.isEmpty(info.getStartDate())){
				out0102.setStartDate(DateUtil.toDate(info.getStartDate(),DateUtil.PATTERN_YYMMDD));
			}
			if(!StringUtils.isEmpty(info.getBunho())){
				out0102.setBunho(info.getBunho());
			}
			if(!StringUtils.isEmpty(info.getGubun1())){
				out0102.setGubun(info.getGubun1());
			}
			if(!StringUtils.isEmpty(info.getJohap())){
				out0102.setJohap(info.getJohap());
			}
			if(!StringUtils.isEmpty(info.getGaein())){
				out0102.setGaein(info.getGaein());
			}
			if(!StringUtils.isEmpty(info.getPiname())){
				out0102.setPiname(info.getPiname());
			}
			if(!StringUtils.isEmpty(info.getBoninGubun())){
				out0102.setBonGaGubun(info.getBoninGubun());
			}
			if(!StringUtils.isEmpty(info.getEndDate())){
				out0102.setEndDate(DateUtil.toDate(info.getEndDate(),DateUtil.PATTERN_YYMMDD));
			}
			else{
				out0102.setEndDate(DateUtil.toDate("9998/12/31", DateUtil.PATTERN_YYMMDD));
			}
			
			if(!StringUtils.isEmpty(info.getGaeinNo())){
				out0102.setGaeinNo(info.getGaeinNo());
			}
			if(!StringUtils.isEmpty(info.getLastCheckDate())){
				out0102.setLastCheckDate(DateUtil.toDate(info.getLastCheckDate(), DateUtil.PATTERN_YYMMDD));
			}
			if(!StringUtils.isEmpty(info.getChuidukDate())){
				out0102.setChuidukDate(DateUtil.toDate(info.getChuidukDate(),DateUtil.PATTERN_YYMMDD));
			}
			out0102.setHospCode(hospCode);
			out0102List.add(out0102);
		}
		
		out0102Repository.save(out0102List);
	}
	
	private Integer updateOut0102(NuroModelProto.NuroOUT0101U02GridBoheomInfo info, String userId, String hospCode) {
		Date startDate = DateUtil.toDate(info.getStartDate(),DateUtil.PATTERN_YYMMDD);
		Date endDate = DateUtil.toDate(info.getEndDate(),DateUtil.PATTERN_YYMMDD);
		Date lastCheckDate = DateUtil.toDate(info.getLastCheckDate(),DateUtil.PATTERN_YYMMDD);
		Date chuidukDate = DateUtil.toDate(info.getChuidukDate(),DateUtil.PATTERN_YYMMDD);
		Date oldStartDate = DateUtil.toDate(info.getOldStartDate(),DateUtil.PATTERN_YYMMDD);

		Integer rs = out0102Repository.updateNuroOUT0101U02UpdateBoheom(userId, new Date(), startDate, info.getBunho(), info.getGubun1(),
				info.getJohap(), info.getGaein(), info.getPiname(), info.getBoninGubun(), endDate, info.getGaeinNo(),
				lastCheckDate, chuidukDate, hospCode, info.getOldGubun(), oldStartDate);
		LOGGER.info("updateOut0102 rs=" + rs);
		return rs;
	}
	
	private void insertOut0105(NuroModelProto.NuroOUT0101U02GridGongbiListInfo info, String userId, String hospCode) {
		Out0105 out0105 = new Out0105();
		out0105.setSysId(userId);
		out0105.setUpdDate(new Date());
		out0105.setUpdId(userId);
		out0105.setHospCode(hospCode);
		out0105.setStartDate(DateUtil.toDate(info.getStartDate(),DateUtil.PATTERN_YYMMDD));
		out0105.setBunho(info.getBunho());
		out0105.setBudamjaBunho(info.getBudamjaBunho());
		out0105.setGongbiCode(info.getGongbiCode());
		out0105.setSugubjaBunho(info.getSugubjaBunho());
		out0105.setEndDate(DateUtil.toDate(info.getEndDate(),DateUtil.PATTERN_YYMMDD));
		out0105.setRemark(info.getRemark());
		out0105.setLastCheckDate(DateUtil.toDate(info.getLastCheckDate(),DateUtil.PATTERN_YYMMDD));
		out0105Repository.save(out0105);
		LOGGER.info(out0105.toString());
	}

	private List<Out0101> saveOrcaPatientInfo(List<NuroModelProto.NuroOUT0101U02GridPatientInfo> patientList, String userId,
								 String hospCode, boolean isOrca, NuroServiceProto.OUT0101U02SaveGridResponse.Builder response, String language) throws Exception {
		List<Out0101> saveList = new ArrayList<>();
		if(CollectionUtils.isEmpty(patientList)) return saveList;
		
		for (NuroModelProto.NuroOUT0101U02GridPatientInfo info : patientList) {
			List<Out0101> ptList = out0101Repository.getByBunho(hospCode, info.getBunho());
			String sex = ifs0003Repository.getCodeByHospCodeAndMapGubunAndIfCode(hospCode, "IF_ORCA_SEX", info.getSex());
			NuroModelProto.NuroOUT0101U02GridPatientInfo patientInfo =  info.toBuilder().setSex(sex).build();
			if (CollectionUtils.isEmpty(ptList)) {
				Out0101 pt = insertPatient(patientInfo, userId, hospCode, patientInfo.getBunho(), isOrca, language);
				saveList.add(pt);
			} else {
				Out0101 out = ptList.get(0);
				out.setUpdId(userId);
				out.setSuname(patientInfo.getSuname());
				out.setSuname2(patientInfo.getSuname2());
				out.setSex(patientInfo.getSex());
				out.setBirth(DateUtil.toDate(patientInfo.getBirth(), DateUtil.PATTERN_YYMMDD));
				out.setZipCode1(patientInfo.getZipCode1());
				out.setZipCode2(patientInfo.getZipCode2());
				out.setAddress1(patientInfo.getAddress1());
				out.setAddress2(patientInfo.getAddress2());
				if(isTelChange(out, patientInfo)) {
					out.setTel(patientInfo.getTel());
					out.setTel1(patientInfo.getTel1());
					out.setTelHp(patientInfo.getTelHp());
					out.setTelGubun(patientInfo.getTelType());
					out.setTelGubun2(patientInfo.getTelType2());
					out.setTelGubun3(patientInfo.getTelType3());
					out.setGubun(patientInfo.getType());	
				}				
				
				out.setBunhoType(patientInfo.getPatientType());
				out.setBillingType(patientInfo.getBillingType());
				out0101Repository.save(out);
				saveList.add(out);
			}
		}
		
		return saveList;
	}
	
	private boolean isTelChange(Out0101 out, NuroModelProto.NuroOUT0101U02GridPatientInfo patientInfo) {
		Set<String> r = new HashSet<>(); 

		r.add(telCombine(out.getTel(), out.getTelGubun()));
		r.add(telCombine(out.getTel1(), out.getTelGubun2()));
		r.add(telCombine(out.getTelHp(), out.getTelGubun3()));
		
		r.add(telCombine(patientInfo.getTel(), patientInfo.getTelType()));
		r.add(telCombine(patientInfo.getTel1(), patientInfo.getTelType2()));
		r.add(telCombine(patientInfo.getTelHp(), patientInfo.getTelType3()));
		
		return r.size() > 3;
	}
	
	private String telCombine(String tel, String type) {
		return String.format("%s-%s", tel == null ? "null" : tel, tel == null ? "null" : (type == null ? "null" : type));
	}

	private void saveOrcaBoheomInfo(List<NuroModelProto.NuroOUT0101U02GridBoheomInfo> boheomList, String userId, String hospCode) throws Exception {
		if(CollectionUtils.isEmpty(boheomList)) return;
		List<String> bunhoList = new ArrayList<>();
		for (NuroModelProto.NuroOUT0101U02GridBoheomInfo info : boheomList) {
			if(!bunhoList.contains(info.getBunho())){
				bunhoList.add(info.getBunho());
			}
		}
		
		out0102Repository.deleteOut0102ByBunhoAndHospCode(hospCode, bunhoList);
		insertOut0102List(boheomList, userId, hospCode);
	}

	private void saveOrcaGongbiList(List<NuroModelProto.NuroOUT0101U02GridGongbiListInfo> gongbiList,
								NuroServiceProto.OUT0101U02SaveGridResponse.Builder response,
								String userId, String hospCode, String language) throws Exception {

		if(CollectionUtils.isEmpty(gongbiList)) return;
		List<String> bunhoList = new ArrayList<>();
		for (NuroModelProto.NuroOUT0101U02GridGongbiListInfo info : gongbiList) {
			if(!bunhoList.contains(info.getBunho())){
				bunhoList.add(info.getBunho());
			}
		}
		
		out0105Repository.deleteOut0105ByHospCodeAndBunho(hospCode, bunhoList);
		List<Out0105> out0105List = new ArrayList<>();
		
		for (NuroModelProto.NuroOUT0101U02GridGongbiListInfo info : gongbiList) {
			Out0105 out0105 = new Out0105();
			out0105.setSysId(userId);
			out0105.setUpdDate(new Date());
			out0105.setUpdId(userId);
			out0105.setHospCode(hospCode);
			out0105.setStartDate(DateUtil.toDate(info.getStartDate(),DateUtil.PATTERN_YYMMDD));
			out0105.setBunho(info.getBunho());
			out0105.setBudamjaBunho(info.getBudamjaBunho());
			out0105.setGongbiCode(info.getGongbiCode());
			out0105.setSugubjaBunho(info.getSugubjaBunho());
			out0105.setEndDate(DateUtil.toDate(info.getEndDate(),DateUtil.PATTERN_YYMMDD));
			out0105.setRemark(info.getRemark());
			out0105.setLastCheckDate(DateUtil.toDate(info.getLastCheckDate(),DateUtil.PATTERN_YYMMDD));
			
			out0105.setSysDate(new Date());
			out0105List.add(out0105);
		}
		
		out0105Repository.save(out0105List);
	}
	
}
