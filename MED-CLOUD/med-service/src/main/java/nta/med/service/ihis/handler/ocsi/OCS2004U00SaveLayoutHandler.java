package nta.med.service.ihis.handler.ocsi;

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

import nta.med.core.domain.ocs.Ocs2005;
import nta.med.core.domain.ocs.Ocs2006;
import nta.med.core.glossary.DataRowState;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs2004Repository;
import nta.med.data.dao.medi.ocs.Ocs2005Repository;
import nta.med.data.dao.medi.ocs.Ocs2006Repository;
import nta.med.service.ihis.proto.OcsiModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2004U00SaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
public class OCS2004U00SaveLayoutHandler
		extends ScreenHandler<OcsiServiceProto.OCS2004U00SaveLayoutRequest, SystemServiceProto.UpdateResponse> {

	private static final Log LOGGER = LogFactory.getLog(OCS2004U00SaveLayoutHandler.class);
	
	@Resource
	private Ocs2004Repository ocs2004Repository;
	
	@Resource
	private Ocs2005Repository ocs2005Repository;
	
	@Resource
	private Ocs2006Repository ocs2006Repository;
	
	@Override
	@Transactional
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2004U00SaveLayoutRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String userId = request.getMemb();
		String inputGwa = request.getInputGwa();
		String inputDoctor = request.getInputDoctor();
		
		List<OcsiModelProto.OCS2004U00layOCS2005Info> grd2005 = request.getLay2005List();
		List<OcsiModelProto.OCS2004U00layOCS2006Info> grd2006 = request.getLay2006List();
		
		if(!CollectionUtils.isEmpty(grd2005)){
			for (OcsiModelProto.OCS2004U00layOCS2005Info info : grd2005) {
				response = handleOcs2005(hospCode, userId, inputGwa, inputDoctor, info);
			}
			
			if(!response.getResult()){
				LOGGER.info(String.format("Handle Grid OCS2005 fail, hosp_code = %s", hospCode));
				return response.build();
			}
		}
		
		if(!CollectionUtils.isEmpty(grd2006)){
			for (OcsiModelProto.OCS2004U00layOCS2006Info info : grd2006) {
				response = handleOcs2006(hospCode, userId, inputGwa, inputDoctor, info);
				
				if(!response.getResult()){
					LOGGER.info(String.format("Handle Grid OCS2005 fail, hosp_code = %s", hospCode));
					return response.build();
				}
			}
		}
		
		response.setResult(true);
		return response.build();
	}

	private UpdateResponse.Builder handleOcs2005(String hospCode, String userId, String inputGwa, String inputDoctor, OcsiModelProto.OCS2004U00layOCS2005Info info){
		UpdateResponse.Builder response = UpdateResponse.newBuilder();
		Date sysDate = Calendar.getInstance().getTime();
		String drtToTime = !StringUtils.isEmpty(info.getDrtToDate()) && StringUtils.isEmpty(info.getDrtToTime()) ? "2359" : info.getDrtToTime();
		String continueYn = StringUtils.isEmpty(info.getDrtToDate()) && StringUtils.isEmpty(info.getDrtToTime()) ? "Y" : info.getContinueYn();
		
		if(DataRowState.ADDED.getValue().equals(info.getDataRowState())){
			Ocs2005 ocs2005 = insertOcs2005(hospCode, userId, drtToTime, continueYn, sysDate, inputGwa, inputDoctor, info);
			if(ocs2005 == null || ocs2005.getId() == null){
				LOGGER.info(String.format("Insert OCS2005 fail, hosp_code = %s", hospCode));
				response.setResult(false);
				return response;
			}
		}
		else if(DataRowState.MODIFIED.getValue().equals(info.getDataRowState())){
			int rowUpdated = ocs2005Repository.updateOcs2005InOCS2004U00SaveLayout(userId
					, info.getDirectCont1()
					, info.getDirectCont2()
					, info.getDirectText()
					, DateUtil.toDate(info.getDrtFromDate(), DateUtil.PATTERN_YYMMDD)
					, DateUtil.toDate(info.getDrtToDate(), DateUtil.PATTERN_YYMMDD)
					, drtToTime
					, info.getDrtFromTime()
					, continueYn
					, info.getJusikYudong()
					, info.getBusikYudong()
					, info.getJoriType()
					, info.getKumjisik()
					, CommonUtils.parseDouble(info.getPkocs2005())
					, hospCode);
			
			if(rowUpdated <= 0){
				LOGGER.info(String.format("Update OCS2005 fail, hosp_code = %s", hospCode));
				response.setResult(false);
				return response;
			}
		}
		else if(DataRowState.DELETED.getValue().equals(info.getDataRowState())){
			// delete OCS2006
			ocs2006Repository.deleteByHospCodefkOcs2005(hospCode, CommonUtils.parseDouble(info.getPkocs2005()));
			
			// delete OCS2005
			ocs2005Repository.deleteByHospCodePkOcs2005(hospCode, CommonUtils.parseDouble(info.getPkocs2005()));
		}
		
		response.setResult(true);
		return response;
	}
	
	private UpdateResponse.Builder handleOcs2006(String hospCode, String userId, String inputGwa, String inputDoctor, OcsiModelProto.OCS2004U00layOCS2006Info info){
		UpdateResponse.Builder response = UpdateResponse.newBuilder();
		Date sysDate = Calendar.getInstance().getTime();
		
		if(DataRowState.ADDED.getValue().equals(info.getDataRowState())){
			Double seq = ocs2006Repository.getNextSeqByHospCodePkOcs2005(hospCode, CommonUtils.parseDouble(info.getPkocs2005()));
			//List<Ocs2005> lstOcs2005 = ocs2005Repository.findByHospCodePkocs2005(hospCode, CommonUtils.parseDouble(info.getPkocs2005()));
			//Double pkSeq = CollectionUtils.isEmpty(lstOcs2005) ? 0.0 : lstOcs2005.get(0).getPkSeq();
			Ocs2006 ocs2006 = insertOcs2006(hospCode, userId, sysDate, seq, info);
			if(ocs2006 == null || ocs2006.getId() == null){
				LOGGER.info(String.format("Insert OCS2006 fail, hosp_code = %s", hospCode));
				response.setResult(false);
				return response;
			}
		}
		else if(DataRowState.MODIFIED.getValue().equals(info.getDataRowState())){
			int rowUpdated = ocs2006Repository.updateOcs2006InOCS2004U00SaveLayout(userId
					, info.getHangmogCode()
					, CommonUtils.parseDouble(info.getSuryang())
					, CommonUtils.parseDouble(info.getNalsu())
					, info.getOrdDanui()
					, info.getBogyongCode()
					, info.getJusaCode()
					, info.getJusaSpdGubun()
					, CommonUtils.parseDouble(info.getDv())
					, info.getDvTime()
					, CommonUtils.parseDouble(info.getInsulinFrom())
					, CommonUtils.parseDouble(info.getInsulinTo())
					, info.getTimeGubun()
					, info.getBomYn()
					, CommonUtils.parseDouble(info.getBomSourceKey())
					, info.getDirectGubun()
					, info.getDirectCode()
					, info.getDirectDetail()
					, CommonUtils.parseDouble(info.getPkocs2005())
					, CommonUtils.parseDouble(info.getSeq())
					, hospCode);
			
			if(rowUpdated <= 0){
				LOGGER.info(String.format("Update OCS2006 fail, hosp_code = %s", hospCode));
				response.setResult(false);
				return response;
			}
		}
		else if(DataRowState.DELETED.getValue().equals(info.getDataRowState())){
			// delete OCS2006
			ocs2006Repository.deleteByHospCodefkOcs2005(hospCode, CommonUtils.parseDouble(info.getPkocs2005()));
			
			// delete OCS2005
			ocs2005Repository.deleteByHospCodePkOcs2005(hospCode, CommonUtils.parseDouble(info.getPkocs2005()));
		}
		
		response.setResult(true);
		return response;
	}
	
	private Ocs2005 insertOcs2005(String hospCode, String userId, String drtToTime, String continueYn, Date sysDate, String inputGwa, String inputDoctor, OcsiModelProto.OCS2004U00layOCS2005Info info){
		Ocs2005 ocs2005 = new Ocs2005();
		ocs2005.setSysDate(sysDate);
		ocs2005.setUpdId(userId);
		ocs2005.setUpdDate(sysDate);
		ocs2005.setBunho(info.getBunho());
		ocs2005.setPkocs2005(CommonUtils.parseDouble(info.getPkocs2005()));
		ocs2005.setInputGwa(inputGwa);
		ocs2005.setInputDoctor(inputDoctor);
		ocs2005.setFkinp1001(CommonUtils.parseDouble(info.getFkinp1001()));
		ocs2005.setOrderDate(DateUtil.toDate(info.getOrderDate(), DateUtil.PATTERN_YYMMDD));
		ocs2005.setInputGubun(info.getInputGubun());
		ocs2005.setInputId(userId);
		ocs2005.setPkSeq(CommonUtils.parseDouble(info.getPkSeq()));
		ocs2005.setDirectGubun(info.getDirectGubun());
		ocs2005.setDirectCode(info.getDirectCode());
		ocs2005.setDirectCont1(info.getDirectCont1());
		ocs2005.setDirectCont2(info.getDirectCont2());
		ocs2005.setDirectText(info.getDirectText());
		ocs2005.setHospCode(hospCode);
		ocs2005.setSysId(userId);
		ocs2005.setDrtFromDate(DateUtil.toDate(info.getDrtFromDate(), DateUtil.PATTERN_YYMMDD));
		ocs2005.setDrtToDate(DateUtil.toDate(info.getDrtToDate(), DateUtil.PATTERN_YYMMDD));
		ocs2005.setContinueYn(continueYn);
		ocs2005.setJusikYudong(info.getJusikYudong());
		ocs2005.setBusikYudong(info.getBusikYudong());
		ocs2005.setJoriType(info.getJoriType());
		ocs2005.setKumjisik(info.getKumjisik());
		ocs2005.setDrtToTime(drtToTime);
		ocs2005.setDrtFromTime(info.getDrtFromTime());
		
		ocs2005Repository.save(ocs2005);
		return ocs2005;
	}
	
	public Ocs2006 insertOcs2006(String hospCode, String userId, Date sysDate, Double seq, OcsiModelProto.OCS2004U00layOCS2006Info info){
		Ocs2006 ocs2006 = new Ocs2006();
		ocs2006.setSysDate(sysDate);
		ocs2006.setUpdId(userId);
		ocs2006.setUpdDate(sysDate);
		ocs2006.setBunho(info.getBunho());
		ocs2006.setFkocs2005(CommonUtils.parseDouble(info.getPkocs2005()));
		ocs2006.setSysId(userId);
		ocs2006.setFkinp1001(CommonUtils.parseDouble(info.getFkinp1001()));
		ocs2006.setOrderDate(DateUtil.toDate(info.getOrderDate(), DateUtil.PATTERN_YYMMDD));
		ocs2006.setInputGubun(info.getInputGubun());
		ocs2006.setDirectGubun(info.getDirectGubun());
		ocs2006.setDirectCode(info.getDirectCode());
		ocs2006.setPkSeq(CommonUtils.parseDouble(info.getPkSeq()));
		ocs2006.setSeq(seq);
		ocs2006.setDirectDetail(info.getDirectDetail());
		ocs2006.setHospCode(hospCode);
		ocs2006.setHangmogCode(info.getHangmogCode());
		ocs2006.setSuryang(CommonUtils.parseDouble(info.getSuryang()));
		ocs2006.setNalsu(CommonUtils.parseDouble(info.getNalsu()));
		ocs2006.setOrdDanui(info.getOrdDanui());
		ocs2006.setBogyongCode(info.getBogyongCode());
		ocs2006.setJusaCode(info.getJusaCode());
		ocs2006.setJusaSpdGubun(info.getJusaSpdGubun());
		ocs2006.setDv(CommonUtils.parseDouble(info.getDv()));
		ocs2006.setDvTime(info.getDvTime());
		ocs2006.setInsulinFrom(CommonUtils.parseDouble(info.getInsulinFrom()));
		ocs2006.setInsulinTo(CommonUtils.parseDouble(info.getInsulinTo()));
		ocs2006.setTimeGubun(info.getTimeGubun());
		ocs2006.setBomSourceKey(CommonUtils.parseDouble(info.getBomSourceKey()));
		ocs2006.setBomYn(info.getBomYn());
		
		ocs2006Repository.save(ocs2006);
		return ocs2006;
	}
	
}
