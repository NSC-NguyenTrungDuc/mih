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
import nta.med.core.glossary.DataRowState;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.data.dao.medi.inp.Inp1003Repository;
import nta.med.data.dao.medi.ocs.Ocs2005Repository;
import nta.med.data.model.ihis.ocsa.DataStringListItemInfo;
import nta.med.service.ihis.proto.OcsiModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2005U02SaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
public class OCS2005U02SaveLayoutHandler
		extends ScreenHandler<OcsiServiceProto.OCS2005U02SaveLayoutRequest, SystemServiceProto.UpdateResponse> {

	private static final Log LOGGER = LogFactory.getLog(OCS2005U02SaveLayoutHandler.class);
	
	@Resource
	private Ocs2005Repository ocs2005Repository;
	
	@Resource
	private Inp1001Repository inp1001Repository;
	
	@Resource
	private Inp1003Repository inp1003Repository;
	
	@Resource
	private CommonRepository commonRepository;
	
	@Override
	@Transactional
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2005U02SaveLayoutRequest request) throws Exception {
		
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String userId = getUserId(vertx, sessionId);
		String bunho = request.getBunho();
		
		List<OcsiModelProto.OCS2005U02grdOCS2005Info> grdocs2005 = request.getGrdocs2005List();
		if(CollectionUtils.isEmpty(grdocs2005)){
			response.setResult(false);
			return response.build();
		}
		
		for (OcsiModelProto.OCS2005U02grdOCS2005Info info : grdocs2005) {
			
			// Get PKINP1001
			List<DataStringListItemInfo> resultPkInp1001 = inp1001Repository.getPkInp1001Ocs2005U02(hospCode, request.getBunho(), request.getMpressedJaewonYn());
			if(CollectionUtils.isEmpty(resultPkInp1001)){
				resultPkInp1001 = inp1003Repository.OCS2005U02getReserFkInp1001(hospCode, request.getBunho(), "0");
			}
			
			String fkinp1001 = CollectionUtils.isEmpty(resultPkInp1001) ? "0" : resultPkInp1001.get(0).getItem();
			
			// NutCheckFromToDate
			if(isNutCheckFromToDate(hospCode, DateUtil.toDate(info.getDrtFromDate(), DateUtil.PATTERN_YYMMDD), bunho, info.getBldGubun(), info.getPkocs2005(), fkinp1001)){
				LOGGER.info(String.format(
						"NutCheckFromToDate is not pass: hospCode = %s, drtFromDate = %s, bunho = %s, bldGubun = %s, pkocs2005 = %s, fkinp1001 = %s",
						hospCode, info.getDrtFromDate(), bunho, info.getBldGubun(), info.getPkocs2005(), fkinp1001));
				response.setResult(false);
				return response.build();
			}
			
			String continueYn = StringUtils.isEmpty(info.getDrtToDate()) ? "Y" : "N";
			if(DataRowState.ADDED.getValue().equals(info.getDataRowState())){
				Double pkSeq = ocs2005Repository.getNextSeqOcs2005Today(hospCode, bunho, CommonUtils.parseDouble(info.getFkinp1001()));
				
				Ocs2005 ocs2005 = insertOcs2005(hospCode, userId, pkSeq, continueYn, info, bunho);
				if(ocs2005 == null || ocs2005.getId() == null){
					LOGGER.info(String.format("Insert OCS2005 fail, hosp_code = %s", hospCode));
					response.setResult(false);
					return response.build();
				}
			}
			else if(DataRowState.MODIFIED.getValue().equals(info.getDataRowState())){
				ocs2005Repository.updateOcs2005InOCS2005U02SaveLayout(userId
						, DateUtil.toDate(info.getDrtFromDate(), DateUtil.PATTERN_YYMMDD)
						, DateUtil.toDate(info.getDrtToDate(), DateUtil.PATTERN_YYMMDD)
						, info.getDirectCode()
						, info.getDirectCont1()
						, info.getDirectCont2()
						, info.getDirectCont3()
						, info.getDirectCodeD()
						, info.getDirectCont1D()
						, info.getDirectCont2D()
						, info.getDirectCont3D()
						, continueYn
						, info.getKumjisik()
						, info.getNomimono()
						, CommonUtils.parseDouble(info.getPkocs2005())
						, hospCode);
			}
			else if(DataRowState.DELETED.getValue().equals(info.getDataRowState())){
				ocs2005Repository.deleteByHospCodePkOcs2005(hospCode, CommonUtils.parseDouble(info.getPkocs2005()));
			}
		}
		
		response.setResult(true);
		return response.build();
	}
	
	public boolean isNutCheckFromToDate(String hospCode, Date fDate, String bunho, String bldGubun, String pkocs2005, String fkinp1001){
		String strCheck = ocs2005Repository.getOCS2005U02IsNutCheckFromToDate(hospCode, fDate, bunho, bldGubun, pkocs2005, fkinp1001);
		return !"0".equals(strCheck);
	}
	
	public Ocs2005 insertOcs2005(String hospCode, String userId, Double pkSeq, String continueYn, OcsiModelProto.OCS2005U02grdOCS2005Info info, String bunho){
		Ocs2005 ocs2005 = new Ocs2005();
		Date sysDate = Calendar.getInstance().getTime();
		
		String pkocs2005 = commonRepository.getNextVal("OCS2005_SEQ");
		
		ocs2005.setSysDate(sysDate);
		ocs2005.setSysId(userId);
		ocs2005.setUpdDate(sysDate);
		ocs2005.setUpdId(userId);
		ocs2005.setPkocs2005(CommonUtils.parseDouble(pkocs2005));
		ocs2005.setBunho(bunho);
		ocs2005.setFkinp1001(CommonUtils.parseDouble(info.getFkinp1001()));
		ocs2005.setOrderDate(DateUtil.toDate(DateUtil.toString(sysDate, DateUtil.PATTERN_YYMMDD), DateUtil.PATTERN_YYMMDD));
		ocs2005.setInputGubun("D0");
		ocs2005.setInputId(userId);
		ocs2005.setPkSeq(pkSeq);
		ocs2005.setHospCode(hospCode);
		ocs2005.setDrtFromDate(DateUtil.toDate(info.getDrtFromDate(), DateUtil.PATTERN_YYMMDD));
		ocs2005.setDrtToDate(DateUtil.toDate(info.getDrtToDate(), DateUtil.PATTERN_YYMMDD));
		ocs2005.setContinueYn(continueYn);
		ocs2005.setDirectGubun("03");
		ocs2005.setDirectCode(info.getDirectCode());
		ocs2005.setDirectCont1(info.getDirectCont1());
		ocs2005.setDirectCont2(info.getDirectCont2());
		ocs2005.setNomimono(info.getNomimono().trim());
		ocs2005.setKumjisik(info.getKumjisik());
		ocs2005.setBldGubun(info.getBldGubun());
		ocs2005.setDirectCodeD(info.getDirectCodeD());
		ocs2005.setDirectCont1D(info.getDirectCont1D());
		ocs2005.setDirectCont2D(info.getDirectCont2D());
		ocs2005.setDirectCont3D(info.getDirectCont3D());
		ocs2005.setDirectCont3(info.getDirectCont3());
		
		ocs2005Repository.save(ocs2005);
		return ocs2005;
	}
}
