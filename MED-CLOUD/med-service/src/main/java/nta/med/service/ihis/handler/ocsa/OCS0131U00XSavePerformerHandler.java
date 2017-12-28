package nta.med.service.ihis.handler.ocsa;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.common.annotation.Route;
import nta.med.core.domain.ocs.Ocs0131;
import nta.med.core.domain.ocs.Ocs0132;
import nta.med.core.glossary.DataRowState;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ocs.Ocs0131Repository;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0131U00XSavePerformerRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
@Transactional
public class OCS0131U00XSavePerformerHandler
	extends ScreenHandler<OcsaServiceProto.OCS0131U00XSavePerformerRequest, SystemServiceProto.UpdateResponse> {
	private static final Log LOG = LogFactory.getLog(OCS0131U00XSavePerformerHandler.class);
	
	@Resource
	private Ocs0131Repository ocs0131Repository;
	
	@Resource
	private Ocs0132Repository ocs0132Repository;
	
	@Override
	@Route(global = true)
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0131U00XSavePerformerRequest request) throws Exception {
		
        SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
    	List<OcsaModelProto.OCS0131U00GrdOCS0131Info> listItem1 = request.getGrdocs0131InfoList();
    	String language = getLanguage(vertx, sessionId);
    	if (!CollectionUtils.isEmpty(listItem1)) {
			for (OcsaModelProto.OCS0131U00GrdOCS0131Info item : listItem1) {
				if(DataRowState.ADDED.getValue().equals(item.getDataRowState())) {
					Ocs0131 ocs0131 = new Ocs0131();
					ocs0131.setSysDate(new Date());
					ocs0131.setSysId(request.getUserId());
					ocs0131.setUpdDate(new Date());
					ocs0131.setCodeType(item.getCodeType());
					ocs0131.setCodeTypeName(item.getCodeTypeName());
					ocs0131.setAdminGubun("USER");
					ocs0131.setMent(item.getMent());
					ocs0131.setChoiceUser(item.getChoiceUser());
					ocs0131.setLanguage(language);
					
					ocs0131Repository.save(ocs0131);
				} else if(DataRowState.MODIFIED.getValue().equals(item.getDataRowState())) {
					ocs0131Repository.updateXSavePerformer(request.getUserId(), new Date(), item.getCodeTypeName(), item.getMent()
							, item.getChoiceUser(), item.getCodeType(), language);
					
				} else if(DataRowState.DELETED.getValue().equals(item.getDataRowState())) {
					ocs0131Repository.deleteXSavePerformer(item.getCodeType(), language);
				}
			}
    	}
    	
    	response.setResult(true);
    	return response.build();
	}
	
	@Override
	@Route(global = false)
	public UpdateResponse postHandle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS0131U00XSavePerformerRequest request, UpdateResponse rs) throws Exception {
		
		SystemServiceProto.UpdateResponse.Builder response = rs.toBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		
		List<OcsaModelProto.OCS0131U00GrdOCS0132Info> listItem2 = request.getGrdocs0132InfoList();
    	if (!CollectionUtils.isEmpty(listItem2)) {
			for (OcsaModelProto.OCS0131U00GrdOCS0132Info item : listItem2) {
				Double sortKey = CommonUtils.parseDouble(item.getSortKey());
				Double valuePoint = CommonUtils.parseDouble(item.getValuePoint());
				if(DataRowState.ADDED.getValue().equals(item.getDataRowState())) {
					Ocs0132 ocs0132 = new Ocs0132();
					ocs0132.setSysDate(new Date());
					ocs0132.setSysId(request.getUserId());
					ocs0132.setUpdDate(new Date());
					ocs0132.setCode(item.getCode());
					ocs0132.setCodeName(item.getCodeName());
					ocs0132.setCodeType(item.getCodeType());
					if(sortKey != null){
						ocs0132.setSortKey(sortKey);
					} else {
						ocs0132.setSortKey(0D);
					}
					ocs0132.setGroupKey(item.getGroupKey());
					ocs0132.setMent(item.getMent());
					if(valuePoint != null){
						ocs0132.setValuePoint(valuePoint);
					} else {
						ocs0132.setValuePoint(0D);
					}
					ocs0132.setHospCode(hospCode);
					ocs0132.setLanguage(getLanguage(vertx, sessionId));
					ocs0132Repository.save(ocs0132);
				} else if(DataRowState.MODIFIED.getValue().equals(item.getDataRowState())) {
					ocs0132Repository.updateXSavePerformer(request.getUserId(), new Date(), item.getCodeName(), sortKey, item.getGroupKey(),
							item.getMent(), valuePoint, item.getCodeType(), item.getCode(), hospCode);
				} else if(DataRowState.DELETED.getValue().equals(item.getDataRowState())) {
					ocs0132Repository.deleteXSavePerformer(item.getCodeType(), item.getCode(), hospCode);
				}
			}
    	}
		
    	response.setResult(true);
		return response.build();
	}
	
}
