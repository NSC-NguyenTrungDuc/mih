package nta.med.service.ihis.handler.nuro;

import static nta.med.common.remoting.rpc.message.RpcMessageFormatter.format;

import java.math.BigDecimal;
import java.util.Date;
import java.util.List;
import java.util.concurrent.TimeUnit;

import javax.annotation.Resource;

import org.apache.commons.lang.RandomStringUtils;
import org.apache.commons.lang.StringUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.common.remoting.rpc.message.RpcMessageParser;
import nta.med.common.util.concurrent.future.FutureEx;
import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.bas.Bas0102;
import nta.med.core.domain.out.Out0101;
import nta.med.core.domain.out.Out0102;
import nta.med.core.domain.out.Out0105;
import nta.med.core.glossary.AccountingConfig;
import nta.med.core.glossary.DataRowState;
import nta.med.core.glossary.MaxSequence;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.data.dao.medi.out.Out0102Repository;
import nta.med.data.dao.medi.out.Out0105Repository;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

/**
 * @author DEV-TiepNM
 */

@Service
@Scope("prototype")
@Transactional
public class NUR2016Q00CreateTempIDHandler extends ScreenHandler<NuroServiceProto.NUR2016Q00CreateTempIDRequest, SystemServiceProto.UpdateResponse> {
	
	private static final Log LOGGER = LogFactory.getLog(NUR2016Q00CreateTempIDHandler.class);
	
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
    private Bas0102Repository bas0102Repository;

    @Override
    public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, NuroServiceProto.NUR2016Q00CreateTempIDRequest request) throws Exception {
        SystemServiceProto.UpdateResponse.Builder updateResponse = SystemServiceProto.UpdateResponse.newBuilder();
        NuroModelProto.NUR2016Q00CreateTempIDInfo info = request.getTempItem();
		
        try {
        	String hospCodeLink = info.getHospCode();
			List<Out0101> out0101s = out0101Repository.getByBunho(getHospitalCode(vertx, sessionId), info.getBunho());
			List<Out0102> out0102s = out0102Repository.findByHospCodeBunho(getHospitalCode(vertx, sessionId), info.getBunho());
			List<Out0105> out0105s = out0105Repository.findByHospCodeBunho(getHospitalCode(vertx, sessionId), info.getBunho());
			if(CollectionUtils.isEmpty(out0101s)){
				LOGGER.info("Not found patient: " + info.getBunho() + ", hosp_code = " + getHospitalCode(vertx, sessionId));
				updateResponse.setResult(false);
				return updateResponse.build(); 
			}
			
			List<Bas0102> bas0102List = bas0102Repository.findByHospCodeAndCodeType(hospCodeLink, AccountingConfig.ACCT_TYPE.getValue());
			boolean useExtAccounting = !CollectionUtils.isEmpty(bas0102List) && AccountingConfig.ACCCT_TYPE_ORCA.getValue().equalsIgnoreCase(bas0102List.get(0).getCode());
			String nextSeq = "";
			
			if(useExtAccounting){
				NuroServiceProto.CreatePatientRequest rq = createExtRequest(hospCodeLink, out0101s.get(0), out0102s, out0105s);
				FutureEx<NuroServiceProto.CreatePatientResponse> res = send(vertx, parser, rq, hospCodeLink); //
				NuroServiceProto.CreatePatientResponse r = res.get(30, TimeUnit.SECONDS);
				
				if(r == null || NuroServiceProto.CreatePatientResponse.Result.SUCCESS != r.getResult() || r.getNewPatientCode() == null){
					LOGGER.info("CREATE TMP PATIENT FAIL: HOSP_CODE = " + hospCodeLink);
					if(r != null) {
						LOGGER.info("response from remote gateway: " + format(r));
						LOGGER.info("ORCA RESULT: " + r.getMessageCode());
					}
					
					updateResponse.setResult(false);
					return updateResponse.build();
				}
				
				LOGGER.info("response from remote gateway: " + format(r));
				nextSeq = r.getNewPatientCode();
			} else {
				String seqInc = commonRepository.getSeqInc("OUT0101_SEQ", info.getHospCode());
            	nextSeq = commonRepository.getNextBunho("OUT0101_SEQ", seqInc, info.getHospCode());
    			if (!StringUtils.isEmpty(nextSeq)) {
    				if((new BigDecimal(nextSeq).compareTo(MaxSequence.OUT0101_MAX_SEQUENCE.getValue())) == 1){
    					LOGGER.error("Out of sequence OUT0101_SEQ, hosp_code = " + info.getHospCode());
    					updateResponse.setResult(false);
    					throw new ExecutionException(updateResponse.build());
    				}
    			}
			}
			
			Out0101 out = out0101s.get(0);
            Out0101 tmpPatient = insertOut0101(out, nextSeq, info.getHospCode(), getUserId(vertx, sessionId));
            if(tmpPatient == null){
            	LOGGER.error("Create tmpPatient fail !!!");
                updateResponse.setResult(false);
                throw new ExecutionException(updateResponse.build());
            }
            
            for (Out0102 out0102 : out0102s) {
				insertOut0102(out0102, info.getHospCode(), tmpPatient.getBunho(), getUserId(vertx, sessionId));
			}
            
            for (Out0105 out0105 : out0105s) {
				insertOut0105(out0105, info.getHospCode(), tmpPatient.getBunho(), getUserId(vertx, sessionId));
			}
            
            updateResponse.setResult(true);
			
//        	if(request.getOrcaPatient()){
//        		Integer status = out0101Repository.updateOut0101OrcaPatient(info.getHospCode(), info.getBunho());
//        		updateResponse.setResult(status != null && status > 0);
//        	}
        	
        } catch (Exception e) {
        	LOGGER.error("Exception when create temp patient: ", e);        	
            updateResponse.setResult(false);
            throw new ExecutionException(updateResponse.build());
        }
		
        return updateResponse.build();
    }
    
    private Out0101 insertOut0101(Out0101 out, String seq, String hospCode, String userId){
        Out0101 out0101 = new Out0101();
        out0101.setBunho(StringUtils.leftPad(seq, 9, "0"));
        out0101.setHospCode(hospCode);
        out0101.setSuname(out.getSuname());
        out0101.setSuname2(out.getSuname2());
        out0101.setBirth(out.getBirth());
        out0101.setBunhoType("3");

        Date date = new Date();
        out0101.setSysDate(date);
        out0101.setSysId(userId);
        out0101.setUpdDate(date);
        out0101.setUpdId(userId);
        out0101.setSex(out.getSex());
        out0101.setZipCode1(out.getZipCode1());
        out0101.setZipCode2(out.getZipCode2());
        out0101.setAddress1(out.getAddress1());
        out0101.setAddress2(out.getAddress2());
        out0101.setTel(out.getTel());
        out0101.setTel1(out.getTel1());
        out0101.setGubun(out.getGubun());
        out0101.setTelHp(out.getTelHp());
        out0101.setEmail(out.getEmail());

        out0101.setTelGubun(out.getTelGubun());
        out0101.setTelGubun2(out.getTelGubun2());
        out0101.setTelGubun3(out.getTelGubun3());
        out0101.setDeleteYn(out.getDeleteYn());
        out0101.setPaceMakerYn(out.getPaceMakerYn());
        out0101.setSelfPaceMaker(out.getSelfPaceMaker());
        out0101.setBunhoExt(out.getBunhoExt());
        out0101.setPwd(RandomStringUtils.randomAlphabetic(8).toUpperCase());
        out0101Repository.save(out0101);
        
        return out0101;
    }
    
    private Out0102 insertOut0102(Out0102 out, String hospCode, String bunho, String userId){
    	Out0102 out0102 = new Out0102();
    	out0102.setSysId(userId);
    	out0102.setUpdId(userId);
    	out0102.setHospCode(hospCode);
    	out0102.setStartDate(out.getStartDate());
    	out0102.setBunho(bunho);
    	out0102.setGubun(out.getGubun());
    	out0102.setJohap(out.getJohap());
    	out0102.setEndDate(out.getEndDate());
    	out0102.setGaein(out.getGaein());
    	out0102.setPiname(out.getPiname());
    	out0102.setBonGaGubun(out.getBonGaGubun());
    	out0102.setRemark(out.getRemark());
    	out0102.setGaeinNo(out.getGaeinNo());
    	out0102.setLastCheckDate(out.getLastCheckDate());
    	out0102.setChuidukDate(out.getChuidukDate());
    	out0102.setIfValidYn(out.getIfValidYn());
    	
    	out0102Repository.save(out0102);
    	return out0102;
    }
    
    private Out0105 insertOut0105(Out0105 out, String hospCode, String bunho, String userId){
    	Out0105 out0105 = new Out0105();
    	out0105.setSysId(userId);
    	out0105.setStartDate(out.getStartDate());
    	out0105.setBunho(bunho);
    	out0105.setBudamjaBunho(out.getBudamjaBunho());
    	out0105.setGongbiCode(out.getGongbiCode());
    	out0105.setSugubjaBunho(out.getSugubjaBunho());
    	out0105.setEndDate(out.getEndDate());
    	out0105.setRemark(out.getRemark());
    	out0105.setUpdId(userId);
    	out0105.setHospCode(hospCode);
    	out0105.setIfValidYn(out.getIfValidYn());
    	
    	out0105Repository.save(out0105);
    	return out0105;
    }

    private NuroServiceProto.CreatePatientRequest createExtRequest(String hospCode, Out0101 pt, List<Out0102> out0102s, List<Out0105> out0105s){
    	
		NuroServiceProto.CreatePatientRequest.Builder requestBuilder = NuroServiceProto.CreatePatientRequest.newBuilder()
				.setId(System.currentTimeMillis())
				.setHospCode(hospCode)
				.setModKey("2");
		
		NuroModelProto.NuroOUT0101U02GridPatientInfo.Builder patientInfo = NuroModelProto.NuroOUT0101U02GridPatientInfo.newBuilder();
		patientInfo.setBunho("00000000*");
		patientInfo.setSuname(pt.getSuname() == null ? "" : pt.getSuname());
		patientInfo.setSuname2(pt.getSuname2() == null ? "" : pt.getSuname2());
		patientInfo.setSex(pt.getSex());
		patientInfo.setBirth(DateUtil.toString(pt.getBirth(), DateUtil.PATTERN_YYMMDD));
		patientInfo.setZipCode1(pt.getZipCode1() == null ? "" : pt.getZipCode1());
		patientInfo.setZipCode1(pt.getZipCode2() == null ? "" : pt.getZipCode2());
		patientInfo.setTel(pt.getTel() == null ? "" : pt.getTel());
		patientInfo.setTel1(pt.getTel1() == null ? "" : pt.getTel1());
		patientInfo.setType("");
		patientInfo.setTelHp(pt.getTelHp() == null ? "" : pt.getTelHp());
		patientInfo.setEmail(pt.getEmail() == null ? "" : pt.getEmail());
		patientInfo.setTelType(pt.getTelGubun() == null ? "" : pt.getTelGubun());
		patientInfo.setTelType2(pt.getTelGubun2() == null ? "" : pt.getTelGubun2());
		patientInfo.setTelType3(pt.getTelGubun3() == null ? "" : pt.getTelGubun3());
		patientInfo.setPaceMakerYn(pt.getPaceMakerYn() == null ? "" : pt.getPaceMakerYn());
		patientInfo.setSelfPaceMaker(pt.getSelfPaceMaker() == null ? "" : pt.getSelfPaceMaker());
		patientInfo.setPatientType(pt.getBunhoType() == null ? "" : pt.getBunhoType());
		requestBuilder.setPatientProfile(patientInfo);
		
		if(!CollectionUtils.isEmpty(out0102s)){
			for (Out0102 out0102 : out0102s) {
				NuroModelProto.NuroOUT0101U02GridBoheomInfo.Builder boheomInfo = NuroModelProto.NuroOUT0101U02GridBoheomInfo.newBuilder();
				boheomInfo.setStartDate(out0102.getStartDate() == null ? "" : DateUtil.toString(out0102.getStartDate(), DateUtil.PATTERN_YYMMDD));
				boheomInfo.setBunho(out0102.getBunho());
				boheomInfo.setGubun1(out0102.getGubun() == null ? "" : out0102.getGubun());
				boheomInfo.setJohap(out0102.getJohap() == null ? "" : out0102.getJohap());
				boheomInfo.setGaein(out0102.getGaein() == null ? "" : out0102.getGaein());
				boheomInfo.setPiname(out0102.getPiname() == null ? "" : out0102.getPiname());
				boheomInfo.setBoninGubun(out0102.getBonGaGubun() == null ? "" : out0102.getBonGaGubun());
				boheomInfo.setEndDate(out0102.getEndDate() == null ? "" : DateUtil.toString(out0102.getEndDate(), DateUtil.PATTERN_YYMMDD));
				boheomInfo.setGaeinNo(out0102.getGaeinNo() == null ? "" : out0102.getGaeinNo());
				boheomInfo.setLastCheckDate(out0102.getLastCheckDate() == null ? "" : DateUtil.toString(out0102.getLastCheckDate(), DateUtil.PATTERN_YYMMDD));
				boheomInfo.setChuidukDate(out0102.getChuidukDate() == null ? "" : DateUtil.toString(out0102.getChuidukDate(), DateUtil.PATTERN_YYMMDD));
				boheomInfo.setDataRowState(DataRowState.ADDED.getValue());
				requestBuilder.addPublicInsurance(boheomInfo);
			}
		}
		
		if(!CollectionUtils.isEmpty(out0105s)){
			for (Out0105 out0105 : out0105s) {
				NuroModelProto.NuroOUT0101U02GridGongbiListInfo.Builder gongbiInfo = NuroModelProto.NuroOUT0101U02GridGongbiListInfo.newBuilder();
				gongbiInfo.setStartDate(out0105.getStartDate() == null ? "" : DateUtil.toString(out0105.getStartDate(), DateUtil.PATTERN_YYMMDD));
				gongbiInfo.setBunho(out0105.getBunho());
				gongbiInfo.setBudamjaBunho(out0105.getBudamjaBunho() == null ? "" : out0105.getBudamjaBunho());
				gongbiInfo.setGongbiCode(out0105.getGongbiCode() == null ? "" : out0105.getGongbiCode());
				gongbiInfo.setSugubjaBunho(out0105.getSugubjaBunho() == null ? "" : out0105.getSugubjaBunho());
				gongbiInfo.setEndDate(out0105.getEndDate() == null ? "" : DateUtil.toString(out0105.getEndDate(), DateUtil.PATTERN_YYMMDD));
				gongbiInfo.setRemark(out0105.getRemark() == null ? "" : out0105.getRemark());
				gongbiInfo.setLastCheckDate(out0105.getLastCheckDate() == null ? "" : DateUtil.toString(out0105.getLastCheckDate(), DateUtil.PATTERN_YYMMDD));
				gongbiInfo.setDataRowState(DataRowState.ADDED.getValue());
				requestBuilder.addPrivateInsurance(gongbiInfo);
			}
		}
		
		return requestBuilder.build();
    }
}
