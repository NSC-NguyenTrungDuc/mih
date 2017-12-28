package nta.med.service.ihis.handler.ocsi;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.nur.Nur1020;
import nta.med.core.domain.ocs.Ocs2015;
import nta.med.core.domain.ocs.Ocs2016;
import nta.med.core.glossary.DataRowState;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.nur.Nur1020Repository;
import nta.med.data.dao.medi.ocs.Ocs2003Repository;
import nta.med.data.dao.medi.ocs.Ocs2015Repository;
import nta.med.data.dao.medi.ocs.Ocs2016Repository;
import nta.med.data.dao.medi.ocs.Ocs6010Repository;
import nta.med.data.model.ihis.inps.CommonProcResultInfo;
import nta.med.service.ihis.proto.OcsiModelProto.OCS6010U10PopupIAgrdOCS2015Info;
import nta.med.service.ihis.proto.OcsiModelProto.OCS6010U10PopupIAgrdOCS2016Info;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10PopupIASaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
public class OCS6010U10PopupIASaveLayoutHandler
		extends ScreenHandler<OcsiServiceProto.OCS6010U10PopupIASaveLayoutRequest, SystemServiceProto.UpdateResponse> {
	
	private static final Log LOGGER = LogFactory.getLog(OCS6010U10PopupIASaveLayoutHandler.class);
	
	@Resource
	private CommonRepository commonRepository;
	
	@Resource
	private Ocs2015Repository ocs2015Repository;
	
	@Resource
	private Ocs2016Repository ocs2016Repository;
	
	@Resource
	private Nur1020Repository nur1020Repository;

	@Resource
	private Ocs2003Repository ocs2003Repository;
	
	@Resource
	private Ocs6010Repository ocs6010Repository;
	
	@Override
	@Transactional
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS6010U10PopupIASaveLayoutRequest request) throws Exception {
		
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		
		List<OCS6010U10PopupIAgrdOCS2015Info> grdOcs2015 = request.getGrdocs2015List();
		List<OCS6010U10PopupIAgrdOCS2016Info> grdOcs2016 = request.getGrdocs2016List();
		String hospCode = request.getHospCode();
		String userId = request.getUserId();
		String cbxCreateOCS2003YN = request.getCbxcreateocs2003Yn(); 
		
		// grdOcs2015
		for (OCS6010U10PopupIAgrdOCS2015Info item : grdOcs2015) {
			if (DataRowState.ADDED.getValue().equalsIgnoreCase(item.getDataRowState())) {
				Ocs2015 ocs2015 = insertOCS2015(item, hospCode, userId);
				if(ocs2015 == null || ocs2015.getId() == null){
					LOGGER.info(String.format("Insert OCS2015 fail, hosp_code = %s", hospCode));
					throw new ExecutionException(response.setResult(false).build());
				}
			} 
			else if(DataRowState.DELETED.getValue().equalsIgnoreCase(item.getDataRowState())) {
				ocs2015Repository.deleteOCS6010U10PopupIASaveLayout(hospCode, item.getBunho(), CommonUtils.parseDouble(item.getFkinp1001()),
						DateUtil.toDate(item.getOrderDate(), DateUtil.PATTERN_YYMMDD), item.getInputGubun(), CommonUtils.parseDouble(item.getPkSeq()));
			}
		}
		
		// grdOcs2016
		for (OCS6010U10PopupIAgrdOCS2016Info item : grdOcs2016) {
			if (DataRowState.ADDED.getValue().equalsIgnoreCase(item.getDataRowState())) {
				String pkocs2016 = commonRepository.getNextVal("OCS2016_SEQ");
				Ocs2016 ocs2016 = insertOCS2016(item, userId, hospCode,pkocs2016);
				if(ocs2016 == null || ocs2016.getId() == null){
					LOGGER.info(String.format("Insert OCS2016 fail, hosp_code = %s", hospCode));
					throw new ExecutionException(response.setResult(false).build());
				}
				
				if (!StringUtils.isEmpty(item.getBloodSugar())) {
					String strData = nur1020Repository.getDataFromNur1020(hospCode, CommonUtils.parseDouble(item.getFkinp1001()), item.getYmd(), item.getTimeGubun(), "BS");
					if (StringUtils.isEmpty(strData)) {
						insertNur1020(item, userId, hospCode, pkocs2016);
					} else {
						nur1020Repository.updateNur1020PopupIASaveLayout(userId
								, CommonUtils.parseDouble(item.getBloodSugar())
								, hospCode
								, item.getBunho()
								, CommonUtils.parseDouble(item.getFkinp1001())
								, DateUtil.toDate(item.getYmd(), DateUtil.PATTERN_YYMMDD)
								, item.getActTime());
					}
				}
				
				// Execute PR_OCS_DIRECT_ACT_ORDER
				if("true".equalsIgnoreCase(cbxCreateOCS2003YN) && !StringUtils.isEmpty(item.getSuryang()) && CommonUtils.parseDouble(item.getSuryang()) > 0.0){
					LOGGER.info(String.format("START Execute procedure PR_OCS_DIRECT_ACT_ORDER hosp_code = %s",hospCode));
					
					CommonProcResultInfo pResult = ocs6010Repository.callPrOcsDirectActOrder(hospCode
							, item.getBunho()
							, CommonUtils.parseDouble(item.getFkinp1001())
							, DateUtil.toDate(grdOcs2015.get(0).getOrderDate(), DateUtil.PATTERN_YYMMDD)
							, grdOcs2015.get(0).getInputGubun()
							, CommonUtils.parseDouble(item.getFkocs2015())
							, DateUtil.toDate(grdOcs2015.get(0).getActDate(), DateUtil.PATTERN_YYMMDD)
							, grdOcs2015.get(0).getActId());
					
					if(!"0".equals(pResult.getStrResult2())){
						LOGGER.info(String.format("Execute procedure PR_OCS_DIRECT_ACT_ORDER fail, hosp_code = %s, IO_FLAG = %s", pResult.getStrResult2() == null ? "NULL" : pResult.getStrResult2()));
						response.setResult(false);
						return response.build();
					}
				}
			} 
			else if (DataRowState.MODIFIED.getValue().equalsIgnoreCase(item.getDataRowState())) {

				ocs2016Repository.updateOCS6010U10PopupIASaveLayout(CommonUtils.parseDouble(item.getSuryang())
						, CommonUtils.parseDouble(item.getBloodSugar())
						, CommonUtils.parseDouble(item.getSeq())
						, item.getTimeGubun(), hospCode
						, CommonUtils.parseDouble(item.getPkocs2016()));

				nur1020Repository.updateNur1020PopupIASaveLayoutCaseOcs2016(userId
						, item.getBloodSugar()
						, item.getActTime()
						, hospCode
						, item.getBunho()
						, item.getFkinp1001()
						, item.getYmd()
						, item.getTimeGubun());
				
			} else if (DataRowState.DELETED.getValue().equalsIgnoreCase(item.getDataRowState())) {
				int rowDeleted = ocs2003Repository.deleteOCS6010U10PopupIASaveLayout(hospCode, item.getPkocs2016());
				if(rowDeleted > 0){
					nur1020Repository.deleteByHospCodeBunhoPkocs2016PrGubun(hospCode, item.getBunho(), CommonUtils.parseDouble(item.getPkocs2016()), "BS");
					ocs2016Repository.deleteByHospCodePkOcs2016(hospCode, CommonUtils.parseDouble(item.getPkocs2016()));
				}
			}
		}
		
		response.setResult(true);
		return response.build();
	}
	
	private Ocs2015 insertOCS2015(OCS6010U10PopupIAgrdOCS2015Info item, String hospCode, String userId) {
		Ocs2015 ocs2015 = new Ocs2015();
		
		ocs2015.setSysDate(new Date());
		ocs2015.setSysId(userId);
		ocs2015.setUpdDate(new Date());
		ocs2015.setPkocs2015(CommonUtils.parseDouble(item.getPkocs2015()));
		ocs2015.setHospCode(hospCode);
		
		ocs2015.setBunho(item.getBunho());
		ocs2015.setFkinp1001(CommonUtils.parseDouble(item.getFkinp1001()));
		ocs2015.setOrderDate(DateUtil.toDate(item.getOrderDate(), DateUtil.PATTERN_YYMMDD));
		ocs2015.setInputGubun(item.getInputGubun());;
		ocs2015.setInputGwa(item.getInputGwa());
		ocs2015.setInputDoctor(item.getInputDoctor());
		
		ocs2015.setInputId(item.getInputId());
		ocs2015.setPkSeq(CommonUtils.parseDouble(item.getPkSeq()));
		ocs2015.setDrtDate(DateUtil.toDate(item.getOrderDate(), DateUtil.PATTERN_YYMMDD));
		ocs2015.setActDate(DateUtil.toDate(item.getActDate(), DateUtil.PATTERN_YYMMDD));
		
		if (StringUtils.isEmpty(item.getActDate())) {
			ocs2015.setActId(null);
		} else {
			ocs2015.setActId(item.getActId());
		}
		
		ocs2015.setActResultText(item.getActResultText());
		ocs2015.setBloodSugar(CommonUtils.parseDouble(item.getBloodSugar()));
		ocs2015.setFkocs2005(CommonUtils.parseDouble(item.getFkocs2005()));
		ocs2015Repository.save(ocs2015);
		
		return ocs2015;
	}
	
	private Ocs2016 insertOCS2016(OCS6010U10PopupIAgrdOCS2016Info item, String userId, String hospCode, String pkocs2016) {
		Ocs2016 ocs2016 = new Ocs2016();
        
		ocs2016.setSysDate(new Date());
		ocs2016.setSysId(userId);
		ocs2016.setUpdDate(new Date());
		ocs2016.setUpdId(null);
		ocs2016.setHospCode(hospCode);
		
		ocs2016.setPkocs2016(CommonUtils.parseDouble(pkocs2016));
		ocs2016.setFkocs2015(CommonUtils.parseDouble(item.getFkocs2015()));
		ocs2016.setSeq(CommonUtils.parseDouble(item.getSeq()));
		
		ocs2016.setHangmogCode(item.getHangmogCode());
		ocs2016.setSuryang(CommonUtils.parseDouble(item.getSuryang()));
		ocs2016.setBloodSugar(CommonUtils.parseDouble(item.getBloodSugar()));
		ocs2016.setTimeGubun(item.getTimeGubun());
		ocs2016.setOrdDanui(item.getOrdDanui());
		
		ocs2016.setMuhyo(item.getMuhyo());
		ocs2016.setBroughtDrgYn(item.getBroughtDrgYn());
		ocs2016Repository.save(ocs2016);
		return ocs2016;
	}
	
	private void insertNur1020(OCS6010U10PopupIAgrdOCS2016Info item, String userId, String hospCode, String pkocs2016) {
		Nur1020 nur1020 = new Nur1020();

		nur1020.setSysDate(new Date());
		nur1020.setSysId(userId);
		nur1020.setUpdDate(new Date());
		nur1020.setUpdId(userId);
		
		nur1020.setHospCode(hospCode);
		nur1020.setBunho(item.getBunho());
		nur1020.setFkinp1001(CommonUtils.parseDouble(item.getFkinp1001()));
		nur1020.setYmd(DateUtil.toDate(item.getYmd(), DateUtil.PATTERN_YYMMDD));
		
		nur1020.setTimeGubun(item.getTimeGubun());
		nur1020.setPrGubun("BS");
		nur1020.setPrValue(CommonUtils.parseDouble(item.getBloodSugar()));
		nur1020.setFkinp1001(CommonUtils.parseDouble(userId));
		
		nur1020Repository.save(nur1020);
	}

}
