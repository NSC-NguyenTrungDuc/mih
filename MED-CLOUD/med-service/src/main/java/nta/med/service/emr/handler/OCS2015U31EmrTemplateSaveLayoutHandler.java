package nta.med.service.emr.handler;

import java.math.BigDecimal;
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
import nta.med.core.domain.emr.EmrTemplate;
import nta.med.core.glossary.DataRowState;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.emr.EmrTemplateRepository;
import nta.med.service.emr.proto.EmrModelProto;
import nta.med.service.emr.proto.EmrServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

@Service                                                                                                          
@Scope("prototype")
@Transactional

//TODO: DO NOT USE THIS REQUEST ANYMORE
public class OCS2015U31EmrTemplateSaveLayoutHandler extends ScreenHandler<EmrServiceProto.OCS2015U31EmrTemplateSaveLayoutRequest, SystemServiceProto.UpdateResponse> {
	private static final Log LOGGER = LogFactory.getLog(OCS2015U31EmrTemplateSaveLayoutHandler.class);                                    
	@Resource                                                                                                       
	private EmrTemplateRepository emrTemplateRepository;

	@Override
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, EmrServiceProto.OCS2015U31EmrTemplateSaveLayoutRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		List<EmrModelProto.OCS2015U31EmrTemplateSaveLayoutInfo> list = request.getSaveLayoutTemplateItemList();
		String user = request.getUserId();
		if(!CollectionUtils.isEmpty(list)) {
			for (EmrModelProto.OCS2015U31EmrTemplateSaveLayoutInfo info:list){
				if(DataRowState.ADDED.getValue().equals(info.getRowState())) {
					boolean result = insertOCS2015U31EmrTemplateSaveLayout(info, user, getHospitalCode(vertx, sessionId));
					response.setResult(result);
					if (!result) {
						response.setMsg("CMO_M006");
						throw new ExecutionException(response.build());
					}
				} else if(DataRowState.MODIFIED.getValue().equals(info.getRowState())) {
					if (StringUtils.isEmpty(info.getTemplateName())){
						response.setMsg("CMO_M001");
						response.setResult(false);
						throw new ExecutionException(response.build());
					} else {
						// Neu la ADMIN thi update all
						if ("ADMIN".equals(request.getUserGroup()) || request.getUserId().equals(info.getSysId())){
							Integer result = emrTemplateRepository.updateEmrTemplateUpdateTagListTemplate(CommonUtils.parseInteger(info.getTemplateTypeId()),
									info.getDescription(), info.getTemplateName(), info.getTemplateContent(),user , user, CommonUtils.parseInteger(info.getTemplateId()));
							if (result != null && result > 0){
								response.setMsg("CMO_M005");
								response.setResult(true);
							} else {
								response.setMsg("CMO_M006");
								response.setResult(false);
								throw new ExecutionException(response.build());
							}  // Neu la DOCTOR thi SYS_ID = USER_ID thi update
						}
					}
				} else if(DataRowState.DELETED.getValue().equals(info.getRowState())) {
					if ("ADMIN".equals(request.getUserGroup())||request.getUserId().equals(info.getSysId())){
						Integer result = emrTemplateRepository.updateEmrTemplateRemoveTemplate(user, CommonUtils.parseInteger(info.getTemplateId()));
						if (result != null && result > 0){
							response.setMsg("CMO_M005");
							response.setResult(true);
						} else {
							response.setMsg("CMO_M006");
							response.setResult(false);
							throw new ExecutionException(response.build());
						}
					}
				} else if(DataRowState.UNCHANGED.getValue().equals(info.getRowState())) {
					response.setResult(false);
				}
			}
		}
		return response.build();
	}
	 
	private boolean insertOCS2015U31EmrTemplateSaveLayout (EmrModelProto.OCS2015U31EmrTemplateSaveLayoutInfo info, String user, String hospCode) {
		try {
			EmrTemplate emrTemp = new EmrTemplate();
			emrTemp.setEmrTemplateTypeId(CommonUtils.parseInteger(info.getTemplateTypeId()));
			emrTemp.setTemplateName(info.getTemplateName());
			emrTemp.setHospCode(hospCode);
			emrTemp.setPermissionType(info.getPermissionType());
			emrTemp.setActiveFlg(new BigDecimal(1));
			emrTemp.setDescription(info.getDescription());
//			emrTemp.setTemplateContent(info.getTemplateContent());
			emrTemp.setUpdId(user);
			emrTemp.setSysId(user);
//			emrTemp.setCreated(new Timestamp(System.currentTimeMillis()));
//			emrTemp.setUpdated(new Timestamp(System.currentTimeMillis()));
			emrTemplateRepository.save(emrTemp);
			return true;
		} catch (Exception e) {
			LOGGER.error(e.getMessage(), e);
			return false;			
		}
	}
}