package nta.med.service.ihis.handler.ocsa;

import java.util.Date;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.inp.App1001;
import nta.med.core.glossary.DataRowState;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.inp.App1001Repository;
import nta.med.data.dao.medi.out.OutsangRepository;
import nta.med.service.ihis.proto.OcsaModelProto.OcsCHTAPPROVEgrdAPP1001Info;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OcsCHTAPPROVEsaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
@Transactional
public class OcsCHTAPPROVEsaveLayoutHandler
		extends ScreenHandler<OcsaServiceProto.OcsCHTAPPROVEsaveLayoutRequest, SystemServiceProto.UpdateResponse> {
	private static final Log LOGGER = LogFactory.getLog(OcsCHTAPPROVEsaveLayoutHandler.class);
	@Resource
	private App1001Repository app1001Repository;
	@Resource
	private CommonRepository commonRepository;
	@Resource
	private OutsangRepository outsangRepository;
	
	@Override
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OcsCHTAPPROVEsaveLayoutRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		if (CollectionUtils.isEmpty(request.getGrd1001List())){
			LOGGER.info("List : null !!!!!!!!");
			response.setResult(false);
			return response.build();
		}			
		String hospCode = getHospitalCode(vertx, sessionId);
		for (OcsCHTAPPROVEgrdAPP1001Info item : request.getGrd1001List()) {
			if (DataRowState.ADDED.getValue().equals(item.getDataRowState())) {
				String seqNextVal = commonRepository.getNextValByHospCode(hospCode, "APP1001_SEQ");
				if (StringUtils.isEmpty(seqNextVal)) {
					LOGGER.info("Get NextVal APP1001_SEQ : null !!!!!!!!");
					response.setResult(false);
					return response.build();
				}
				if (insertApp1001(hospCode, request.getUserId(), request.getBunho(), item, seqNextVal, request.getAppMode()) < 0) {
					LOGGER.info("ADDED App1001 : fail !!!!!!!!");
					response.setResult(false);
					return response.build();
				}					
			} else if (DataRowState.MODIFIED.getValue().equals(item.getDataRowState())) {
				if (StringUtils.isEmpty(item.getPkApp1001())) {
					LOGGER.info("MODIFIED App1001 : Pkapp1001 null !!!!!!!!");
					response.setResult(false);
					return response.build();
				}
				
				String resultSang = outsangRepository.getOUTSANGU00ResultSang(hospCode, item.getIoGubun(), item.getGwa(), request.getBunho(), item.getFkinp1001(), item.getSangCode()
																, item.getSangName(), item.getPostModifierName(), item.getPreModifierName(), item.getSangStartDate(), item.getSangEndDate()
																, item.getSangJindanDate(), "U", item.getJuSangYn());
				if (StringUtils.isEmpty(resultSang) || (!StringUtils.isEmpty(resultSang) && "Y".equals(resultSang))){
					LOGGER.info("MODIFIED resultSang = null or resultSang = Y !!!!!!!!");
					response.setResult(false);
					return response.build();
				}
					
				if (updateApp1001(hospCode, request.getUserId(), request.getBunho(), item) < 0) {
					LOGGER.info("MODIFIED App1001 : fail !!!!!!!!");
					response.setResult(false);
					return response.build();
				}
			} else if (DataRowState.DELETED.getValue().equals(item.getDataRowState())) {
				if (StringUtils.isEmpty(item.getPkApp1001())) {
					LOGGER.info("DELETED App1001 : Pkapp1001 null !!!!!!!!");
					response.setResult(false);
					return response.build();
				}
				if (deleteApp1001(hospCode, item.getPkApp1001()) < 0) {
					LOGGER.info("DELETED App1001 : fail !!!!!!!!");
					response.setResult(false);
					return response.build();
				}
			} else {
				LOGGER.info("Data row state : null !!!!!!!!");
				response.setResult(false);
				return response.build();
			}
		}
		response.setResult(true);
		return response.build();
	}
	
	private Integer insertApp1001(String hospCode, String userId, String bunho, OcsCHTAPPROVEgrdAPP1001Info item, String seqNextVal, String appMode) {
		App1001 app1001 = new App1001();
		app1001.setSysDate(new Date());
		app1001.setSysId(userId);
		app1001.setBunho(bunho);
		app1001.setHospCode(hospCode);
		app1001.setGwa(item.getGwa());
		app1001.setIoGubun(item.getIoGubun());
		app1001.setDoctor(item.getDoctor());
		app1001.setFkinp1001(CommonUtils.parseDouble(item.getFkinp1001()));
		app1001.setInputId(userId);
		app1001.setSangCode(item.getSangCode());
		app1001.setJuSangYn(item.getJuSangYn());
		app1001.setSangName(item.getSangName());
		app1001.setSangStartDate(DateUtil.toDate(item.getSangStartDate(), DateUtil.PATTERN_YYMMDD));
		app1001.setSangEndDate(DateUtil.toDate(item.getSangEndDate(), DateUtil.PATTERN_YYMMDD));
		app1001.setSangEndSayu(item.getSangEndSayu());
		app1001.setPreModifier1(item.getPreModifier1());
		app1001.setPreModifier2(item.getPreModifier2());
		app1001.setPreModifier3(item.getPreModifier3());
		app1001.setPreModifier4(item.getPreModifier4());
		app1001.setPreModifier5(item.getPreModifier5());
		app1001.setPreModifier6(item.getPreModifier6());
		app1001.setPreModifier7(item.getPreModifier7());
		app1001.setPreModifier8(item.getPreModifier8());
		app1001.setPreModifier9(item.getPreModifier9());
		app1001.setPreModifier10(item.getPreModifier10());
		app1001.setPreModifierName(item.getPreModifierName());
		app1001.setPostModifier1(item.getPostModifier1());
		app1001.setPostModifier2(item.getPostModifier2());
		app1001.setPostModifier3(item.getPostModifier3());
		app1001.setPostModifier4(item.getPostModifier4());
		app1001.setPostModifier5(item.getPostModifier5());
		app1001.setPostModifier6(item.getPostModifier6());
		app1001.setPostModifier7(item.getPostModifier7());
		app1001.setPostModifier8(item.getPostModifier8());
		app1001.setPostModifier9(item.getPostModifier9());
		app1001.setPostModifier10(item.getPostModifier10());
		app1001.setPostModifierName(item.getPostModifierName());
		app1001.setSangJindanDate(DateUtil.toDate(item.getSangJindanDate(), DateUtil.PATTERN_YYMMDD));
		app1001.setPkapp1001(CommonUtils.parseDouble(seqNextVal));
		app1001.setInsteadYn(item.getInsteadYn());
		app1001.setInsteadId(item.getInsteadId());
		app1001.setInsteadDate(DateUtil.toDate(item.getInsteadDate(), DateUtil.PATTERN_YYMMDD));
		app1001.setInsteadTime(item.getInsteadTime());
		app1001.setApproveYn(item.getApproveYn());
		app1001.setApproveId(item.getApproveId());
		app1001.setApproveDate(DateUtil.toDate(item.getApproveDate(), DateUtil.PATTERN_YYMMDD));
		app1001.setApproveTime(item.getApproveTime());
		app1001.setPostapproveYn(item.getPostapproveYn());
		if ("Y".equals(appMode)) {
			app1001.setApproveYn("Y");
			app1001.setApproveId(userId);
			app1001.setApproveDate(new Date());
			app1001.setApproveTime(DateUtil.getCurrentHH24MI());
		} else {
			app1001.setInsteadYn("Y");
			app1001.setInsteadId(userId);
			app1001.setInsteadDate(new Date());
			app1001.setInsteadTime(DateUtil.getCurrentHH24MI());
			app1001.setApproveYn("N");
		}
		App1001 app1001Check = app1001Repository.save(app1001);
		if (app1001Check != null && app1001Check.getId() != null) 
			return 1;
		return -1;
	}
	
	private Integer updateApp1001(String hospCode, String userId, String bunho, OcsCHTAPPROVEgrdAPP1001Info item) {
		if (app1001Repository.updateApp1001(userId, item.getInsteadYn(), item.getInsteadId(), DateUtil.toDate(item.getInsteadDate(), DateUtil.PATTERN_YYMMDD), item.getInsteadTime()
										, item.getApproveYn(), item.getApproveId(), DateUtil.toDate(item.getApproveDate(), DateUtil.PATTERN_YYMMDD), item.getApproveTime(), item.getPostapproveYn()
										, DateUtil.toDate(item.getSangStartDate(), DateUtil.PATTERN_YYMMDD), DateUtil.toDate(item.getSangEndDate(), DateUtil.PATTERN_YYMMDD), item.getSangEndSayu(), DateUtil.toDate(item.getSangJindanDate(), DateUtil.PATTERN_YYMMDD)
										, item.getJuSangYn(), item.getPreModifier1(), item.getPreModifier2(), item.getPreModifier3(), item.getPreModifier4()
										, item.getPreModifier5(), item.getPreModifier6(), item.getPreModifier7(), item.getPreModifier8(), item.getPreModifier9()
										, item.getPreModifier10(), item.getPreModifierName(), item.getPostModifier1(), item.getPostModifier2(), item.getPostModifier3()
										, item.getPostModifier4(), item.getPostModifier5(), item.getPostModifier6(), item.getPostModifier7(), item.getPostModifier8()
										, item.getPostModifier9(), item.getPostModifier10(), item.getPostModifierName(), hospCode, CommonUtils.parseDouble(item.getPkApp1001())) > 0)
			return 1;
		return -1;
	}
	
private Integer deleteApp1001(String hospCode, String pkapp1001) {
		if (app1001Repository.deleteApp1001(hospCode, CommonUtils.parseDouble(pkapp1001)) > 0)
			return 1;
		return -1;
	}
}
