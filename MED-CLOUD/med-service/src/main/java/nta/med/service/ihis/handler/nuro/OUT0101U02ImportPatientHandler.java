package nta.med.service.ihis.handler.nuro;

import java.util.ArrayList;
import java.util.Collections;
import java.util.Date;
import java.util.List;
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
import nta.med.common.util.DateTimes;
import nta.med.common.util.concurrent.future.FutureEx;
import nta.med.common.util.i18n.HalfFullConverter;
import nta.med.core.domain.bas.Bas0102;
import nta.med.core.domain.out.Out0101;
import nta.med.core.domain.out.TmpPatient;
import nta.med.core.glossary.AccountingConfig;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.BaseRepository;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.data.dao.medi.out.Out0102Repository;
import nta.med.data.dao.medi.out.TmpPatientRepository;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.NuroServiceProto.OUT0101U02ImportPatientRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
@Transactional(rollbackFor = Exception.class)
public class OUT0101U02ImportPatientHandler extends ScreenHandler<NuroServiceProto.OUT0101U02ImportPatientRequest, SystemServiceProto.UpdateResponse>{

	private static final Log LOGGER = LogFactory.getLog(OUT0101U02ImportPatientHandler.class);
	
	private RpcMessageParser parser = new RpcMessageParser(NuroServiceProto.class);

	@Resource
	private Out0101Repository out0101Repository;
	
	@Resource
	private Out0102Repository out0102Repository;
	
	@Resource
	private BaseRepository baseRepository;
	
	@Resource
	private Bas0102Repository bas0102Repository;
	
	@Resource
	private TmpPatientRepository tmpPatientRepository;
	@Resource
	private CommonRepository commonRepository;
	
//	@Override
//	public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId,
//			OUT0101U02ImportPatientRequest request) throws Exception {
//		setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup("323", "JA", "", 1));
//	}
	
	@Override
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OUT0101U02ImportPatientRequest request) throws Exception {
		
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		List<NuroModelProto.OUT0101U02ImportPatientInfo> patientListInfo = request.getPatientsList();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		String sysId = getUserId(vertx, sessionId);
		
		if(CollectionUtils.isEmpty(patientListInfo)){
			response.setResult(false);
			return response.build();
		}
		
		boolean useApi = false;
		boolean saveResult = false;
		List<Bas0102> bas0102List = bas0102Repository.findByHospCodeAndCodeType(hospCode, AccountingConfig.ACCT_TYPE.getValue());
		useApi = !CollectionUtils.isEmpty(bas0102List) && AccountingConfig.ACCCT_TYPE_ORCA.getValue().equalsIgnoreCase(bas0102List.get(0).getCode());
		
		List<String> listImportFail = new ArrayList<String>();
		saveResult = savePatientList(vertx, hospCode, language, sysId, patientListInfo, useApi, request.getIgnoreDuplicate(), listImportFail);
		response.setResult(saveResult);
		return response.build();
	}
	
	public boolean savePatientList(Vertx vertx, String hospCode, String language, String sysId, List<NuroModelProto.OUT0101U02ImportPatientInfo> patientListInfo, boolean useApi, boolean ignoreDuplicate, List<String> listImportFail){
		List<TmpPatient> patientList = new ArrayList<TmpPatient>();
		List<Integer> bunhoList = new ArrayList<Integer>();
		Date sysDate = new Date();
		long timeOffset = DateTimes.parse("yyyy-MM-dd HH:mm:ss.SSS", "2016-01-01 00:00:00.000");
		String contextID = String.valueOf((System.currentTimeMillis() - timeOffset)/1000);
		String ignoreDuplicateYn = ignoreDuplicate ? "Y" : "N";
		
		for (NuroModelProto.OUT0101U02ImportPatientInfo info : patientListInfo) {
			TmpPatient patient = new TmpPatient();
			patient.setSysDate(sysDate);
			patient.setSysId(contextID);
			patient.setUpdDate(sysDate);
			patient.setUpdId(sysId);
			patient.setHospCode(hospCode);
			patient.setGubun("Z0");
			patient.setSex(info.getSex());
			patient.setBunho(CommonUtils.rPad(info.getBunho(), 9, "0"));
			patient.setSuname(info.getSuname());
			patient.setBirth(DateUtil.toDate(info.getBirth(), DateUtil.PATTERN_YYMMDD));
			patient.setPwd(RandomStringUtils.randomAlphabetic(8).toUpperCase());
			patient.setBunhoType("0");
			if("JA".equalsIgnoreCase(language)){
				if(!StringUtils.isEmpty(info.getZipCode()) && info.getZipCode().length() >= 7){
					patient.setZipCode1(info.getZipCode().substring(0, 3));
					patient.setZipCode2(info.getZipCode().substring(3, 7));
				}
				patient.setAddress1(info.getAddress1() + " " + info.getAddress2());
				patient.setAddress2(info.getAddress3());
				patient.setBillingType("I");
				patient.setSuname2(CommonUtils.convertToHalfWidthKana(info.getSuname2()));
			} else {
				patient.setAddress1(info.getAddress1());
				patient.setAddress2(info.getAddress2());
				patient.setTel(info.getTel());
				patient.setBillingType("N");
				patient.setSuname2(info.getSuname2());
			}
			
			patientList.add(patient);
		}
		
		if(useApi){
			for (TmpPatient pt : patientList) {
				savePatientByApi(hospCode, vertx, pt);
			}
			
			return true;
		} else {
			LOGGER.info("Start import patient, hosp_code = " + hospCode);
			//tmpPatientRepository.deleteByHospCode(hospCode);
			
			baseRepository.saveObjects(patientList);
			String msg = out0101Repository.callProcMergePatient(hospCode, contextID,ignoreDuplicateYn);
			// update sequence
			if("0".equals(msg)){
				for (TmpPatient tmp : patientList) {
					try {
						Integer patientId = CommonUtils.parseInteger(tmp.getBunho());
						if (patientId  != null)
							bunhoList.add(patientId);
					} catch (Exception e) {
					// Do nothing
				}
			}
							
			if(!CollectionUtils.isEmpty(bunhoList)){
				Integer maxBunho = Collections.max(bunhoList);
				String strSeq = commonRepository.getCurrentSeq("OUT0101_SEQ", hospCode);
				if(strSeq != null){
					int currentSeq = CommonUtils.parseInteger(strSeq);
					if(maxBunho > currentSeq){
						maxBunho++;
							// update sequence
						if(commonRepository.updateSequence("OUT0101_SEQ", hospCode, maxBunho) > 0) {
								LOGGER.info("Update SWT_Sequence case success");
						}
					}
				}
			}
							
		}
			LOGGER.info("End import patient, hosp_code = " + hospCode + ", msg = " + msg);
			return "0".equals(msg);
		}
	}
	
	private boolean savePatientByApi(String hospCode, Vertx vertx, TmpPatient patient){
		List<Out0101> pts = out0101Repository.getByBunho(hospCode, patient.getBunho());
		boolean isNewPatient = CollectionUtils.isEmpty(pts);
		try {
			NuroServiceProto.CreatePatientRequest.Builder patientRq = NuroServiceProto.CreatePatientRequest.newBuilder();
			NuroModelProto.NuroOUT0101U02GridPatientInfo.Builder patientInfo = NuroModelProto.NuroOUT0101U02GridPatientInfo.newBuilder()
					.setBunho(isNewPatient ? "00000000*" : patient.getBunho())
					.setSuname(HalfFullConverter.toFullWidth(patient.getSuname()))
					.setSuname2(HalfFullConverter.toFullWidthKana(patient.getSuname2()))
					.setSex(patient.getSex())
					.setBirth(DateUtil.toString(patient.getBirth(), DateUtil.PATTERN_YYMMDD) )
					.setZipCode1(patient.getZipCode1() == null ? "" : patient.getZipCode1())
					.setZipCode2(patient.getZipCode2() == null ? "" : patient.getZipCode2())
					.setAddress1(patient.getAddress1() == null ? "" : patient.getAddress1())
					.setAddress2(patient.getAddress2() == null ? "" : patient.getAddress2());
			
			patientRq.setId(System.currentTimeMillis());
			patientRq.setHospCode(hospCode);
			patientRq.setModKey("2");
			patientRq.setPatientProfile(patientInfo);
			
			if(isNewPatient){
				NuroModelProto.NuroOUT0101U02GridBoheomInfo.Builder insInfo = NuroModelProto.NuroOUT0101U02GridBoheomInfo
						.newBuilder()
						.setStartDate(DateUtil.toString(new Date(), DateUtil.PATTERN_YYMMDD))
						.setBunho("00000000*")
						.setGubun1("Z0")
						.setEndDate("9999/12/31")
						.setDataRowState("Added");
				
				patientRq.addPublicInsurance(insInfo);
			}
			
			FutureEx<NuroServiceProto.CreatePatientResponse> res = send(vertx, parser, patientRq.build(), hospCode);
			NuroServiceProto.CreatePatientResponse r = res.get(30, TimeUnit.SECONDS);
			if(r.hasResult() && r.getResult() == NuroServiceProto.CreatePatientResponse.Result.SUCCESS){
				LOGGER.error("Import patient (Call API) " + patient.getBunho() + " was successfull: ");
			} else {
				LOGGER.error("Import patient (Call API) " + patient.getBunho() + " was fail: error code = " + r.getMessageCode());
				return false;
			}
		} catch (Exception e) {
			LOGGER.error("Exception when Import patient (Call API) " + patient.getBunho(), e);
			return false;
		}
		
		return true;
	}
	
}
