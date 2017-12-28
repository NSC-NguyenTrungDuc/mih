package nta.med.service.ihis.handler.nuri;

import java.util.Calendar;
import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.nur.Nur0102;
import nta.med.core.domain.nur.Nur0401;
import nta.med.core.domain.nur.Nur0403;
import nta.med.core.domain.nur.Nur0404;
import nta.med.core.glossary.DataRowState;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.nur.Nur0102Repository;
import nta.med.data.dao.medi.nur.Nur0401Repository;
import nta.med.data.dao.medi.nur.Nur0402Repository;
import nta.med.data.dao.medi.nur.Nur0403Repository;
import nta.med.data.dao.medi.nur.Nur0404Repository;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR0401U01SaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
public class NUR0401U01SaveLayoutHandler
		extends ScreenHandler<NuriServiceProto.NUR0401U01SaveLayoutRequest, SystemServiceProto.UpdateResponse> {

	private static final Log LOGGER = LogFactory.getLog(NUR0401U01SaveLayoutHandler.class);
	
	@Resource
	private Nur0102Repository nur0102Repository;
	
	@Resource
	private Nur0404Repository nur0404Repository;
	
	@Resource
	private Nur0403Repository nur0403Repository;
	
	@Resource
	private Nur0402Repository nur0402Repository;
	
	@Resource
	private Nur0401Repository nur0401Repository;
	
	@Override
	@Transactional
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR0401U01SaveLayoutRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		String userId = getUserId(vertx, sessionId);
		
		List<NuriModelProto.NUR0401U01GrdNur0102Info> grdNur0102 = request.getGrdNur0102List();
		List<NuriModelProto.NUR0401U01GrdNur0401Info> grdNur0401 = request.getGrdNur0401List();
		List<NuriModelProto.NUR0401U01GrdNur0403Info> grdNur0403 = request.getGrdNur0403List();
		List<NuriModelProto.NUR0401U01GrdNur0404Info> grdNur0404 = request.getGrdNur0404List();
	
		response = handleGrdNur0102(hospCode, userId, language, grdNur0102);
		if(!response.getResult()){
			LOGGER.info(String.format("Handle grdNur0102 fail: hosp_code = %s", hospCode));
			throw new ExecutionException(response.build());
		}
		
		response = handleGrdNur0401(hospCode, userId, grdNur0401);
		if(!response.getResult()){
			LOGGER.info(String.format("Handle grdNur0401 fail: hosp_code = %s", hospCode));
			throw new ExecutionException(response.build());
		}
		
		response = handleGrdNur0403(hospCode, userId, grdNur0403);
		if(!response.getResult()){
			LOGGER.info(String.format("Handle grdNur0403 fail: hosp_code = %s", hospCode));
			throw new ExecutionException(response.build());
		}
		
		response = handleGrdNur0404(hospCode, userId, grdNur0404);
		if(!response.getResult()){
			LOGGER.info(String.format("Handle grdNur0404 fail: hosp_code = %s", hospCode));
			throw new ExecutionException(response.build());
		}
		
		response.setResult(true);
		return response.build();
	}
	
	private SystemServiceProto.UpdateResponse.Builder handleGrdNur0102(String hospCode, String userId, String language,
			List<NuriModelProto.NUR0401U01GrdNur0102Info> grdNur0102) {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		Date sysDate = Calendar.getInstance().getTime();
		
		for (NuriModelProto.NUR0401U01GrdNur0102Info info : grdNur0102) {
			if(DataRowState.ADDED.getValue().equals(info.getDataRowState())){
				Nur0102 nur0102 = new Nur0102();
				nur0102.setSysDate(sysDate);
				nur0102.setSysId(userId);
				nur0102.setUpdDate(sysDate);
				nur0102.setUpdId(userId);
				nur0102.setHospCode(hospCode);
				nur0102.setCodeType("NUR_PLAN_BUNRYU");
				nur0102.setCode(info.getNurPlanBunryu());
				nur0102.setCodeName(info.getNurPlanBunryuName());
				nur0102.setSortKey(CommonUtils.parseDouble(info.getSortKey()));
				nur0102.setLanguage(language);
				nur0102Repository.save(nur0102);
			}
			else if(DataRowState.MODIFIED.getValue().equals(info.getDataRowState())){
				nur0102Repository.updateByHospCodeCodeTypeCode(userId, sysDate, "NUR_PLAN_BUNRYU", info.getNurPlanBunryu(), info.getNurPlanBunryuName(),
						CommonUtils.parseDouble(info.getSortKey()), hospCode, language);
			}
			else if(DataRowState.DELETED.getValue().equals(info.getDataRowState())){
				// delete NUR0404
				nur0404Repository.deleteNur0404InNUR0401U01(hospCode, info.getNurPlanBunryu());
				
				// delete NUR0403
				nur0403Repository.deleteNUR0403InNUR0401U01(hospCode, info.getNurPlanBunryu());
				
				// delete NUR0402
				nur0402Repository.deleteNUR0402InNUR0401U01(hospCode, info.getNurPlanBunryu());
				
				// delete NUR0401
				nur0401Repository.deleteByHospCodeNurPlanBunryu(hospCode, info.getNurPlanBunryu());
				
				// delete NUR0102
				nur0102Repository.deleteNUR0101U01Case2Deleted(hospCode, language, "NUR_PLAN_BUNRYU", info.getNurPlanBunryu());
			}
		}
		
		response.setResult(true);
		return response;
	}

	
	private SystemServiceProto.UpdateResponse.Builder handleGrdNur0401(String hospCode, String userId,
			List<NuriModelProto.NUR0401U01GrdNur0401Info> grdNur0401) {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		Date sysDate = Calendar.getInstance().getTime();
		
		for (NuriModelProto.NUR0401U01GrdNur0401Info info : grdNur0401) {
			if(DataRowState.ADDED.getValue().equals(info.getDataRowState())){
				List<Nur0401> items = nur0401Repository.findByHospCodeNurPlanJin(hospCode, info.getNurPlanJin());
				if(!CollectionUtils.isEmpty(items)){
					LOGGER.info(String.format("Duplicate key Nur0401: hosp_code = %s, NurPlanJin = %s", hospCode, info.getNurPlanJin()));
					response.setResult(false);
					response.setMsg("M1|" + info.getNurPlanJin());
					return response;
				}
				
				Nur0401 nur0401 = new Nur0401();
				nur0401.setSysDate(sysDate);
				nur0401.setSysId(userId);
				nur0401.setUpdDate(sysDate);
				nur0401.setUpdId(userId);
				nur0401.setHospCode(hospCode);
				nur0401.setNurPlanJin(info.getNurPlanJin());
				nur0401.setNurPlanJinName(info.getNurPlanJinName());
				nur0401.setNurPlanBunryu(info.getNurPlanBunryu());
				nur0401.setVald("Y");
				nur0401.setSortKey(CommonUtils.parseDouble(info.getSortKey()));
				
				nur0401Repository.save(nur0401);
			}
			else if(DataRowState.MODIFIED.getValue().equals(info.getDataRowState())){
				nur0401Repository.updateNur0401ByHospCodeNurPlanJin(userId, info.getNurPlanJinName(),
						info.getNurPlanBunryu(), info.getVald(), CommonUtils.parseDouble(info.getSortKey()), hospCode, info.getNurPlanJin());
			}
			else if(DataRowState.DELETED.getValue().equals(info.getDataRowState())){
				// delete NUR0404
				nur0404Repository.deleteByHospCodeNurPlanJin(hospCode, info.getNurPlanJin());
				
				// delete NUR0403
				nur0403Repository.deleteByHospCodeNurPlanJin(hospCode, info.getNurPlanJin());
				
				// delete NUR0402
				nur0402Repository.deleteByHospCodeNurPlanJin(hospCode, info.getNurPlanJin());
				
				// delete NUR0401
				nur0401Repository.deleteByHospCodeNurPlanJin(hospCode, info.getNurPlanJin());
			}
		}
		
		response.setResult(true);
		return response;
	}
	
	private SystemServiceProto.UpdateResponse.Builder handleGrdNur0403(String hospCode, String userId, List<NuriModelProto.NUR0401U01GrdNur0403Info> grdNur0403){
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		Date sysDate = Calendar.getInstance().getTime();
		
		for (NuriModelProto.NUR0401U01GrdNur0403Info info : grdNur0403) {
			if(DataRowState.ADDED.getValue().equals(info.getDataRowState())){
				List<Nur0403> items = nur0403Repository.findByHospCodeNurPlanJinNurPlan(hospCode, info.getNurPlanJin(), CommonUtils.parseDouble(info.getNurPlan()));
				if(!CollectionUtils.isEmpty(items)){
					LOGGER.info(String.format("Duplicate key Nur0403: hosp_code = %s, NurPlanJin = %s, NurPlan = %s", hospCode, info.getNurPlanJin(), info.getNurPlan()));
					response.setResult(false);
					response.setMsg("M2|" + info.getNurPlanJin() + "|" + info.getNurPlanPro() + "|" + info.getNurPlan());
					return response;
				}
				
				Nur0403 nur0403 = new Nur0403();
				nur0403.setSysDate(sysDate);
				nur0403.setSysId(userId);
				nur0403.setUpdDate(sysDate);
				nur0403.setUpdId(userId);
				nur0403.setNurPlanJin(info.getNurPlanJin());
				nur0403.setNurPlanPro(info.getNurPlanPro());
				nur0403.setNurPlan(CommonUtils.parseDouble(info.getNurPlan()));
				nur0403.setNurPlanName(info.getNurPlanName());
				nur0403.setNurPlanOte(info.getNurPlanOte());
				nur0403.setSortKey(CommonUtils.parseDouble(info.getSortKey()));
				nur0403.setFromDate(DateUtil.toDate(DateUtil.toString(sysDate, DateUtil.PATTERN_YYMMDD), DateUtil.PATTERN_YYMMDD));
				nur0403.setEndDate(DateUtil.toDate((StringUtils.isEmpty(info.getEndDate()) ? "9998/12/31" : info.getEndDate()), DateUtil.PATTERN_YYMMDD));
				nur0403.setVald(info.getVald());
				nur0403.setHospCode(hospCode);
				
				nur0403Repository.save(nur0403);
			}
			else if(DataRowState.MODIFIED.getValue().equals(info.getDataRowState())){
				nur0403Repository.updateByHospCodeNurPlanJinNurPlan(userId, info.getNurPlanName(),
						CommonUtils.parseDouble(info.getSortKey()), info.getVald(), hospCode, info.getNurPlanJin(), CommonUtils.parseDouble(info.getNurPlan()));
			}
			else if(DataRowState.DELETED.getValue().equals(info.getDataRowState())){
				// delete NUR0404
				nur0404Repository.deleteByHospCodeNurPlanJinNurPlan(hospCode, info.getNurPlanJin(), CommonUtils.parseDouble(info.getNurPlan()));
				
				// delete NUR0403
				nur0403Repository.deleteByHospCodeNurPlanJinNurPlan(hospCode, info.getNurPlanJin(), CommonUtils.parseDouble(info.getNurPlan()));
			}
		}
		
		response.setResult(true);
		return response;
	}
	
	private SystemServiceProto.UpdateResponse.Builder handleGrdNur0404(String hospCode, String userId, List<NuriModelProto.NUR0401U01GrdNur0404Info> grdNur0404){
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		Date sysDate = Calendar.getInstance().getTime();
		
		for (NuriModelProto.NUR0401U01GrdNur0404Info info : grdNur0404) {
			if(DataRowState.ADDED.getValue().equals(info.getDataRowState())){
				List<Nur0404> items = nur0404Repository.findByHospCodeNurPlanJinNurPlanNurPlanDetail(hospCode,
						info.getNurPlanJin(), CommonUtils.parseDouble(info.getNurPlan()), info.getNurPlanDetail());
				if(!CollectionUtils.isEmpty(items)){
					LOGGER.info(String.format("Duplicate key Nur0404: hosp_code = %s, NurPlanJin = %s, NurPlan = %s, NurPlanDetail = %s"
							, hospCode, info.getNurPlanJin(), info.getNurPlan(), info.getNurPlanDetail()));
					
					response.setResult(false);
					response.setMsg("M3|" + info.getNurPlanJin() + "|" + info.getNurPlanPro() + "|" + info.getNurPlan() + "|" + info.getNurPlanDetail());
					return response;
				}
				
				Nur0404 nur0404 = new Nur0404();
				nur0404.setSysDate(sysDate);
				nur0404.setSysId(userId);
				nur0404.setUpdDate(sysDate);
				nur0404.setUpdId(userId);
				nur0404.setNurPlanJin(info.getNurPlanJin());
				nur0404.setNurPlanPro(info.getNurPlanPro());
				nur0404.setNurPlan(CommonUtils.parseDouble(info.getNurPlan()));
				nur0404.setNurPlanDetail(info.getNurPlanDetail());
				nur0404.setNurPlanDename(info.getNurPlanDename());
				nur0404.setSortKey(CommonUtils.parseDouble(info.getSortKey()));
				nur0404.setFromDate(DateUtil.toDate(DateUtil.toString(sysDate, DateUtil.PATTERN_YYMMDD), DateUtil.PATTERN_YYMMDD));
				nur0404.setEndDate(DateUtil.toDate((StringUtils.isEmpty(info.getEndDate()) ? "9998/12/31" : info.getEndDate()), DateUtil.PATTERN_YYMMDD));
				nur0404.setVald(info.getVald());
				nur0404.setHospCode(hospCode);
				nur0404Repository.save(nur0404);
			}
			else if(DataRowState.MODIFIED.getValue().equals(info.getDataRowState())){
				nur0404Repository.updateByHospCodeNurPlanJinNurPlanNurPlanDetail(userId, info.getNurPlanDename(), CommonUtils.parseDouble(info.getSortKey()), info.getVald(), 
						hospCode, info.getNurPlanJin(), CommonUtils.parseDouble(info.getNurPlan()), info.getNurPlanDetail());
			}
			else if(DataRowState.DELETED.getValue().equals(info.getDataRowState())){
				nur0404Repository.deleteByHospCodeNurPlanJinNurPlanNurPlanDetail(hospCode, info.getNurPlanJin(), CommonUtils.parseDouble(info.getNurPlan()), info.getNurPlanDetail());
			}
		}
		
		response.setResult(true);
		return response;
	}
}
