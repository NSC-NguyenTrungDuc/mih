package nta.med.service.emr.handler;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.emr.EmrTag;
import nta.med.core.glossary.DataRowState;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.emr.EmrTagRepository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.emr.proto.EmrModelProto.OCS2015U30EmrTagSaveLayoutInfo;
import nta.med.service.emr.proto.EmrServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;

import java.math.BigDecimal;
import java.util.List;

@Service                                                                                                          
@Scope("prototype")
@Transactional
public class OCS2015U30EmrTagSaveLayoutHandler extends ScreenHandler<EmrServiceProto.OCS2015U30EmrTagSaveLayoutRequest, SystemServiceProto.UpdateResponse> {
	private static final Log LOGGER = LogFactory.getLog(OCS2015U30EmrTagSaveLayoutHandler.class);                                    
	@Resource                                                                                                       
	private EmrTagRepository emrTagRepository;

	@Override
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, EmrServiceProto.OCS2015U30EmrTagSaveLayoutRequest request) throws Exception {

		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		boolean resultRoot = false;
		boolean result = false;
		String hospitalCode = getHospitalCode(vertx, sessionId);
		List<OCS2015U30EmrTagSaveLayoutInfo> listRoot = request.getSaveLayoutRootItemList();
		if(!CollectionUtils.isEmpty(listRoot)&&"ADMIN".equals(request.getUserGroup())){
			for (OCS2015U30EmrTagSaveLayoutInfo info: listRoot) {
				if(!DataRowState.DELETED.getValue().equals(info.getRowState())) {
					String resultCheck = checkCondition(info, "ADMIN");
					if (!StringUtils.isEmpty(resultCheck)){
						response.setMsg(resultCheck);
						response.setResult(false);
						break;
					}
				}
			}
		}

		List<OCS2015U30EmrTagSaveLayoutInfo> listNode = request.getSaveLayoutNodeItemList();
		if(!CollectionUtils.isEmpty(listNode)){
			for (OCS2015U30EmrTagSaveLayoutInfo info: listNode) {
				if(!DataRowState.DELETED.getValue().equals(info.getRowState())) {
					String resultCheck = checkCondition(info,"OCS");
					if (!StringUtils.isEmpty(resultCheck)){
						response.setMsg(resultCheck);
						response.setResult(false);
						break;
					}
				}
			}
		}
		if(CollectionUtils.isEmpty(listRoot) || !"ADMIN".equals(request.getUserGroup())){
			resultRoot = true;
		}else{
			for (OCS2015U30EmrTagSaveLayoutInfo info: listRoot) {
				if (!DataRowState.UNCHANGED.getValue().equals(info.getRowState())) {
					if(DataRowState.ADDED.getValue().equals(info.getRowState())) {
						resultRoot = addEmrTag(info, info.getTagLevel(), request.getUserId(), "S", false, hospitalCode);
					} else if(DataRowState.MODIFIED.getValue().equals(info.getRowState())) {
						BigDecimal filterFlg = null;
						if ("N".equals(info.getFilterFlg())) {
							filterFlg = new BigDecimal(0);
						} else {
							filterFlg = new BigDecimal(1);
						}
						if(emrTagRepository.updateEmrTagRootInfo(info.getTagCode(), info.getTagName(),
								info.getTagDisplayText(), info.getDescription(), filterFlg, CommonUtils.parseInteger(info.getTagId()))>0){
							resultRoot = true;
						}
					} else if(DataRowState.DELETED.getValue().equals(info.getRowState())) {
						if(emrTagRepository.updateEmrTagRemoveATag(request.getUserId(), CommonUtils.parseInteger(info.getTagId()))>0){
							resultRoot = true;
						}
					}
					if(!resultRoot){
						response.setResult(false);
						throw new ExecutionException(response.build());
					}
				}
			}
		}

		if(CollectionUtils.isEmpty(listNode)){
			result = true;
		}else{
			for (OCS2015U30EmrTagSaveLayoutInfo info: listNode) {
				if (!DataRowState.UNCHANGED.getValue().equals(info.getRowState())) {
					if(DataRowState.ADDED.getValue().equals(info.getRowState())) {
						if("ADMIN".equals(request.getUserGroup())){
							result = addEmrTag(info, info.getTagLevel(), request.getUserId(), "S", true, hospitalCode);
						} else {
							result = addEmrTag(info, info.getTagLevel(), request.getUserId(), "P", true, hospitalCode);
						}
					} else if(DataRowState.MODIFIED.getValue().equals(info.getRowState())) {
						if ("ADMIN".equals(request.getUserGroup())||request.getUserId().equals(info.getSysId())){
							BigDecimal filterFlg = null;
							if ("N".equals(info.getFilterFlg())) {
								filterFlg = new BigDecimal(0);
							} else {
								filterFlg = new BigDecimal(1);
							}
							if(emrTagRepository.updateEmrTagNodeInfo(info.getTagCode(), info.getTagName(), info.getTagDisplayText(),
									info.getDescription(), filterFlg, info.getTagParent(), info.getTagLevel(), CommonUtils.parseInteger(info.getTagId()))>0){
								result = true;
							}
						}
					} else if(DataRowState.DELETED.getValue().equals(info.getRowState())) {
						if ("ADMIN".equals(request.getUserGroup())||request.getUserId().equals(info.getSysId())){
							if(emrTagRepository.updateEmrTagRemoveATag(request.getUserId(), CommonUtils.parseInteger(info.getTagId()))>0){
								result = true;
							}
						}
					}
					if(!result){
						response.setResult(false);
						throw new ExecutionException(response.build());
					}
				}
			}
		}

		if(result && resultRoot){
			response.setResult(true);
		}
		return response.build();
	}
	
	private String checkCondition(OCS2015U30EmrTagSaveLayoutInfo item, String userGroup){
		if (StringUtils.isEmpty(item.getTagCode())||StringUtils.isEmpty(item.getTagName())) {
			return "CMO_M001";
		} else if ("Added".equals(item.getRowState()) && emrTagRepository.checkExistTagCodeCaseAdded(item.getTagCode())>0){
			return "CMO_M002";
		} else if ("Modified".equals(item.getRowState()) && emrTagRepository.checkExistTagCodeCaseModified(item.getTagId(), item.getTagCode())>0){
			return "CMO_M002";
		} else if ("ADMIN".equals(userGroup)&&item.getTagCode().length()>1){
			return "CMO_M009";
		}
		return null;
	}
	
	private boolean addEmrTag(OCS2015U30EmrTagSaveLayoutInfo item, String tagLevel, String userId, String permissionType, boolean parent, String hospitalCode) {
		try {
			EmrTag emrTag = new EmrTag ();
			emrTag.setTagCode(item.getTagCode());
			emrTag.setTagName(item.getTagName());
			emrTag.setTagDisplayText(item.getTagDisplayText());
			emrTag.setDescription(item.getDescription());
			//In the screen of Client, filter_flag have 2 values. There are N and Y correspond with Server is 0 and 1
			BigDecimal filterFlg = null;
    		if ("N".equals(item.getFilterFlg())) {
    			filterFlg = new BigDecimal(0);
    		} else {
    			filterFlg = new BigDecimal(1);
    		}
			emrTag.setFilterFlg(filterFlg);
			emrTag.setActiveFlg(new BigDecimal(1));
			emrTag.setHospCode(hospitalCode);
			emrTag.setTagLevel(tagLevel);
			emrTag.setSysId(userId);
			emrTag.setUpdId(userId);
			if (parent) {
				emrTag.setTagParent(item.getTagParent());
			}
			emrTag.setPermissionType(permissionType);
			emrTagRepository.save(emrTag);
			return true;
		} catch (Exception e){
			LOGGER.error(e.getMessage(), e);
			return false;
		}
	}
}