package nta.med.service.ihis.handler.ocso;

import java.math.BigDecimal;
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

import nta.med.core.domain.ocs.Ocs4001;
import nta.med.core.glossary.DataRowState;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs4001Repository;
import nta.med.data.dao.medi.out.OutsangRepository;
import nta.med.service.ihis.proto.OcsoModelProto.OCS4001U00SaveInfo;
import nta.med.service.ihis.proto.OcsoServiceProto;
import nta.med.service.ihis.proto.OcsoServiceProto.OCS4001U00SaveRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Transactional
@Service                                                                                                          
@Scope("prototype")
public class OCS4001U00SaveHandler extends ScreenHandler<OcsoServiceProto.OCS4001U00SaveRequest, SystemServiceProto.UpdateResponse>{
	private static final Log LOGGER = LogFactory.getLog(OCS4001U00SaveHandler.class);
	
	@Resource
	private OutsangRepository outsangRepository;
	
	@Resource
	private Ocs4001Repository ocs4001Repository;

	@Override
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS4001U00SaveRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String userId = getUserId(vertx, sessionId);
		if (CollectionUtils.isEmpty(request.getItemsList())) {
			response.setResult(false);
		} else {
			for (OCS4001U00SaveInfo item : request.getItemsList()) {
				if(item.getRowState().equalsIgnoreCase(DataRowState.ADDED.getValue())){
					if (StringUtils.isEmpty(item.getBunho())) {
						response.setResult(false);
						LOGGER.info("Insert: Bunho null !!!!");
					} else {
						response.setResult(insertOcs4001(hospCode, item, userId));
					}
				}else if(item.getRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())){
					if (StringUtils.isEmpty(item.getId())) {
						response.setResult(false);
						LOGGER.info("MODEIFY: ID null !!!!!");
					} else {
						response.setResult(updateOcs4001(item.getInputContent(), item.getInputValue(), item.getPrintContent(), item.getId(), userId, item.getPrintDatetime()));
					} 					
				}else if(item.getRowState().equalsIgnoreCase(DataRowState.DELETED.getValue())){
					if (StringUtils.isEmpty(item.getId())) {
						response.setResult(false);
						LOGGER.info("DELETE: ID null !!!!!");
					} else {
						response.setResult(deleteOcs4001(item.getId(), userId));
					}
				}
			}
		}
		
		return response.build();
	}
	
	private boolean insertOcs4001(String hospCode, OCS4001U00SaveInfo info, String userId) {
		Ocs4001 ocs4001 =  new Ocs4001();
		ocs4001.setTlpCode("TPLHIS" + hospCode + info.getTplCode());
		ocs4001.setFormatType(info.getFormatType());
		ocs4001.setFormCode(info.getFormCode());
		ocs4001.setFormName(info.getFormName());
		ocs4001.setInputContent(info.getInputContent());
		ocs4001.setInputValue(info.getInputValue());
		ocs4001.setPrintContent(info.getPrintContent());
		ocs4001.setBunho(info.getBunho());
		ocs4001.setHospCode(hospCode);
		ocs4001.setCreateDate(DateUtil.toString(new Date(), DateUtil.PATTERN_YYMMDD));
		if (!StringUtils.isEmpty(info.getPrintDatetime()))
			ocs4001.setPrintDate(new Date());
		ocs4001.setFromDate(info.getFromDate());
		ocs4001.setToDate(info.getToDate());
		ocs4001.setSysId(StringUtils.isEmpty(info.getSysId()) ? userId : info.getSysId());
		ocs4001.setSysDate(new Date());
		ocs4001.setUpdId(StringUtils.isEmpty(info.getUpdId()) ? userId : info.getUpdId());
		ocs4001.setUpdDate(new Date());
		ocs4001.setActiveFlg(new BigDecimal("1"));
		
		Ocs4001 ocs4001Check = ocs4001Repository.save(ocs4001);
		if (ocs4001Check != null && ocs4001Check.getId() != null) 
			return true;
		return false;
	}
	
	private boolean updateOcs4001(String inputContent, String inputValue, String printContent, String id, String userId, String printDate) {
		if (!StringUtils.isEmpty(printDate))
			if (ocs4001Repository.updateOcs4001Print(CommonUtils.parseLong(id), userId, inputContent, inputValue, printContent, new Date()) > 0) 
				return true;
		if (ocs4001Repository.updateOcs4001Save(CommonUtils.parseLong(id), userId, inputContent, inputValue, printContent) > 0) 
			return true;
		return false;
	}
	
	private boolean deleteOcs4001(String id, String userId) {
		if (ocs4001Repository.deleteOcs4001(CommonUtils.parseLong(id), userId) > 0) 
			return true;
		return false;
	}
}
