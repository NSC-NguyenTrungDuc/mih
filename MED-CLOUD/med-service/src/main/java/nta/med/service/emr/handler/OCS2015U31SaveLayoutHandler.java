package nta.med.service.emr.handler;

import java.math.BigDecimal;
import java.util.ArrayList;
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
import nta.med.core.domain.adm.Adm3200;
import nta.med.core.domain.emr.EmrTagRelation;
import nta.med.core.domain.emr.EmrTemplate;
import nta.med.core.glossary.DataRowState;
import nta.med.core.glossary.EmrTemplateClassify;
import nta.med.core.glossary.Language;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.emr.EmrTagRelationRepository;
import nta.med.data.dao.emr.EmrTemplateRepository;
import nta.med.data.dao.medi.adm.Adm3200Repository;
import nta.med.data.dao.medi.bas.Bas0270Repository;
import nta.med.service.emr.proto.EmrModelProto.OCS2015U31GetEmrTemplateInfo;
import nta.med.service.emr.proto.EmrModelProto.OCS2015U31GetTemplateTagsInfo;
import nta.med.service.emr.proto.EmrServiceProto.OCS2015U31SaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Transactional
@Service
@Scope("prototype")
public class OCS2015U31SaveLayoutHandler extends ScreenHandler<OCS2015U31SaveLayoutRequest, UpdateResponse>{
	
	private static final Log LOGGER = LogFactory.getLog(OCS2015U31SaveLayoutHandler.class);
	
	@Resource
	private EmrTagRelationRepository emrTagRelationRepository;
	
	@Resource
	private EmrTemplateRepository emrTemplateRepository;
	
	@Resource
	private Bas0270Repository bas0270Repository;
	
	@Resource
	private Adm3200Repository adm3200Repository;
	
	private String ROOT = "R";
	
	@Override
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS2015U31SaveLayoutRequest request) throws Exception {
		UpdateResponse.Builder response = UpdateResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		List<Adm3200> adms = adm3200Repository.findByHospCodeUserId(hospCode, getUserId(vertx, sessionId));
		if(CollectionUtils.isEmpty(adms)){
			response.setResult(false);
			return response.build();
		}
		
		boolean isAdmin = "ADMIN".equals(adms.get(0).getUserGroup()) || "SAM".equals(adms.get(0).getUserGroup());
		boolean isClone = "Y".equals(request.getCloneYn());
		if(!isAdmin && isClone){
			response = cloneEmrTemplate(request, hospCode, getUserId(vertx, sessionId));
		} else {
			response = saveOcs2015U31(request, hospCode, isAdmin, getUserId(vertx, sessionId));
		}
		
		if(!response.getResult()){
			throw new ExecutionException(response.build());
		}
		
		return response.build();
	}
	
	private UpdateResponse.Builder saveOcs2015U31(OCS2015U31SaveLayoutRequest request, String hospCode, boolean isAdmin, String sysId){
		boolean save = false;
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		Integer currentTemplateId = 0;
		String level = request.getType();
		String gwa = request.getDeptCode();
		String doctorCode = request.getDoctorCode();
		String templateCode = "";
		String sabun = EmrTemplateClassify.ADM.getValue().equals(level) || EmrTemplateClassify.DEPT.getValue().equals(level) ? "ADM" : doctorCode;
		String permissionType = isAdmin ? "S" : "P";
		
		List<OCS2015U31GetEmrTemplateInfo> listTemplate = request.getListTemplateList();
		if(!CollectionUtils.isEmpty(listTemplate)){
			for(OCS2015U31GetEmrTemplateInfo item : listTemplate){
				Integer count = emrTemplateRepository.checkIfExistsOCS2015U31EmrTemplate(item.getTemplateCode(), hospCode, sabun, gwa, permissionType);
				if(DataRowState.ADDED.getValue().equals(item.getRowState())){
					if(count != 0){
						response.setMsg("01"); 		// It mean already exists template code
						response.setResult(false);
						return response;
					}
					
					EmrTemplate etmp = insertEmrTemplate(item, hospCode, permissionType, sysId, level, gwa, doctorCode);
					save = etmp != null && etmp.getEmrTemplateId() != null;
					if(!save){
						response.setResult(false);
						return response;
					}
					
					currentTemplateId = etmp.getEmrTemplateId();
					templateCode = etmp.getTemplateCode();
				}else if(DataRowState.MODIFIED.getValue().equals(item.getRowState())){
					save = updateEmrTemplate(item, hospCode, sysId);
				}else if(DataRowState.DELETED.getValue().equals(item.getRowState())){
					save = deleteEmrTemplate(item, hospCode, sysId);
				}
				
				if(!save){
					response.setResult(false);
					return response;
				}
			}
		}
		
		List<OCS2015U31GetTemplateTagsInfo> listTemplateTag = request.getListTemplateTagList();
		if(!CollectionUtils.isEmpty(listTemplateTag)){
			for(OCS2015U31GetTemplateTagsInfo item : listTemplateTag){
				if(DataRowState.ADDED.getValue().equals(item.getRowState())){
					if(!StringUtils.isEmpty(item.getTemplateId())){
						currentTemplateId = CommonUtils.parseInteger(item.getTemplateId());
					}
					Boolean isDuplicateKey = emrTagRelationRepository.isExisted(item.getTagChild(), item.getTagParent(), item.getTemplateId(), hospCode);
					if (isDuplicateKey) {
						response.setResult(false);
						response.setMsg("duplicate");
						LOGGER.info("OCS2015U31SaveLayoutHandler Duplicate entry hospCode: " + hospCode + ", TagChild: " + item.getTagChild() + ", TagParent:" + item.getTagParent() + ", TemplateId: " + item.getTemplateId());
					} else {
						save = insertEmrTagRelation(item, hospCode, sysId, currentTemplateId, templateCode, sabun);
					}
				}else if(DataRowState.MODIFIED.getValue().equals(item.getRowState())){
					save = updateEmrTagRelation(item, hospCode, sysId);
				}else if(DataRowState.DELETED.getValue().equals(item.getRowState())){
					save = deleteEmrTagRelation(item, hospCode, sysId);
				}
				
				if(!save) {
					response.setResult(false);
					return response;
				}
			}
		}
		
		response.setResult(true);
		return response;
	}
	
	private UpdateResponse.Builder cloneEmrTemplate(OCS2015U31SaveLayoutRequest request, String hospCode, String doctorCode){
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		response.setResult(false);
		List<OCS2015U31GetEmrTemplateInfo> listTemplate = request.getListTemplateList();
		if(CollectionUtils.isEmpty(listTemplate)) return response;
		
		List<OCS2015U31GetEmrTemplateInfo> userCloneTemplate = new ArrayList<OCS2015U31GetEmrTemplateInfo>();
		for (OCS2015U31GetEmrTemplateInfo tmp : listTemplate) {
			if(tmp.hasUseYn() && "Y".equals(tmp.getUseYn())){
				userCloneTemplate.add(tmp);
			}
		}
		
		if(CollectionUtils.isEmpty(userCloneTemplate)) return response;
		
		List<String> deptList =  bas0270Repository.getGwaBySabunAndHospCode(hospCode, doctorCode);
		if(CollectionUtils.isEmpty(deptList)) return response;
		
		for (OCS2015U31GetEmrTemplateInfo tmp : userCloneTemplate) {
			EmrTemplate et = emrTemplateRepository.findByIdHospCode(CommonUtils.parseInteger(tmp.getTemplateId()), hospCode);
			if(et == null) return response;
			
			// clone EMR_TEMPLATE
			EmrTemplate templateClone = new EmrTemplate();
			BeanUtils.copyProperties(et, templateClone, Language.JAPANESE.toString());
			
			List<EmrTemplate> listTmp = emrTemplateRepository.findByTemplateCodeUserId(tmp.getTemplateCode(), hospCode, doctorCode, "P");
			if(!CollectionUtils.isEmpty(listTmp)){
				String tmpCode = emrTemplateRepository.findLastestTemplateCode(hospCode, et.getTemplateCode(), doctorCode, "P");
				templateClone.setTemplateCode(cloneTemplateCode(tmpCode));
			}
			
			templateClone.setEmrTemplateId(null);
			templateClone.setPermissionType("P");
			templateClone.setLevel(new BigDecimal(EmrTemplateClassify.USER.getValue()));
			templateClone.setGwa(deptList.get(0));
			templateClone.setUpdId(doctorCode);
			templateClone.setSysId(doctorCode);
			templateClone.setSabun(doctorCode);
			templateClone.setCreated(null);
			templateClone.setUpdated(null);
			if(et.getDescription() == null){
				templateClone.setDescription("Copy from " + et.getTemplateCode());
			} else {
				templateClone.setDescription(et.getDescription() + " Copy from " + et.getTemplateCode());
			}
			
			emrTemplateRepository.save(templateClone);
			
			if(templateClone == null || templateClone.getEmrTemplateId() == null) return response;
			
			// clone EMR_TAG_RELATION
			List<EmrTagRelation> listTags = emrTagRelationRepository.findByEmrTemplateId(hospCode, et.getEmrTemplateId());
			if(!CollectionUtils.isEmpty(listTags)){
				List<EmrTagRelation> cloneTagList = new ArrayList<>();
				for (EmrTagRelation tag : listTags) {
					EmrTagRelation cloneTag = new EmrTagRelation();
					BeanUtils.copyProperties(tag, cloneTag, Language.JAPANESE.toString());
					cloneTag.setEmrTagRelationId(null);
					cloneTag.setEmrTemplateId(templateClone.getEmrTemplateId());
					cloneTag.setSysId(doctorCode);
					cloneTag.setUpdId(doctorCode);
					cloneTag.setCreated(null);
					cloneTag.setUpdated(null);
					cloneTagList.add(cloneTag);
				}
				
				emrTagRelationRepository.save(cloneTagList);
			}
		}
		
		response.setResult(true);
		return response;
	}
	
	private EmrTemplate insertEmrTemplate(OCS2015U31GetEmrTemplateInfo item, String hospCode, String permissionType, String sysId, String level, String deptCode, String doctorCode){
		EmrTemplate emrTemplate = new EmrTemplate();
		emrTemplate.setEmrTemplateTypeId(CommonUtils.parseInteger(item.getTemplateTypeId()));
		emrTemplate.setTemplateCode(item.getTemplateCode());
		emrTemplate.setTemplateName(item.getTemplateName());
		emrTemplate.setHospCode(hospCode);
		emrTemplate.setPermissionType(permissionType);
		emrTemplate.setActiveFlg(new BigDecimal(1));
		emrTemplate.setDescription(item.getDescription());
		emrTemplate.setUpdId(sysId);
		emrTemplate.setSysId(sysId);
		emrTemplate.setDefaultFlg(item.getDefaultFlg());
		emrTemplate.setLevel(new BigDecimal(level));
		emrTemplate.setGwa(deptCode);
		emrTemplate.setSabun(EmrTemplateClassify.ADM.getValue().equals(level) || EmrTemplateClassify.DEPT.getValue().equals(level) ? "ADM" : doctorCode);
		
		emrTemplateRepository.save(emrTemplate);
		return emrTemplate;
	}
	
	private boolean updateEmrTemplate(OCS2015U31GetEmrTemplateInfo item, String hospCode, String userId){
		return emrTemplateRepository.updateEmrTemplateUpdateTagListTemplate(
				CommonUtils.parseInteger(item.getTemplateTypeId()),
				item.getDescription(),
				item.getTemplateName(),
				item.getTemplateCode(),
				item.getDefaultFlg(),
				userId,
				CommonUtils.parseInteger(item.getTemplateId())) > 0;
	}
	
	private boolean deleteEmrTemplate(OCS2015U31GetEmrTemplateInfo item, String hospCode,  String userId){
		return emrTemplateRepository.updateEmrTemplateRemoveTemplate(userId, CommonUtils.parseInteger(item.getTemplateId())) > 0;
	}
	
	private boolean insertEmrTagRelation(OCS2015U31GetTemplateTagsInfo item, String hospCode, String sysId, Integer templateId, String templateCode, String userId){
		EmrTagRelation emrTagRelation = new EmrTagRelation();
		emrTagRelation.setEmrTemplateId(templateId);
		if(!StringUtils.isEmpty(item.getTagChild())){
			emrTagRelation.setTagChild(item.getTagChild());	
		}
		emrTagRelation.setTagParent(item.getTagParent());
		emrTagRelation.setActiveFlg(1);
		emrTagRelation.setSysId(sysId);
		emrTagRelation.setUpdId(sysId);
		emrTagRelation.setHospCode(hospCode);
		emrTagRelation.setTagType(CommonUtils.parseBigDecimal(item.getType()));
		emrTagRelation.setDefaultContent(item.getDefaultContent());
		
		emrTagRelationRepository.save(emrTagRelation);
		return true;
	}
	
	private boolean updateEmrTagRelation(OCS2015U31GetTemplateTagsInfo item, String hospCode, String userId){
		return emrTagRelationRepository.updateOCS2015U31TagRelation(
				item.getTagParent(), 
				StringUtils.isEmpty(item.getTagChild()) ? null : item.getTagChild(), 
				userId,
				CommonUtils.parseBigDecimal(item.getType()),
				item.getDefaultContent(),
				CommonUtils.parseInteger(item.getTagId())) > 0;
	}
	
	private boolean deleteEmrTagRelation(OCS2015U31GetTemplateTagsInfo item, String hospCode, String userId){
		Integer deleteResult = 0;
		if(ROOT.equals(item.getTagLevel())){
			deleteResult = emrTagRelationRepository.deleteOCS2015U31TagRelationParent(userId, item.getTagParent(),
					CommonUtils.parseBigDecimal(item.getType()),
					item.getDefaultContent(), hospCode);
		}else{
			deleteResult = emrTagRelationRepository.deleteOCS2015U31TagRelationChild(userId, 
					CommonUtils.parseBigDecimal(item.getType()),
					item.getDefaultContent(), CommonUtils.parseInteger(item.getTagId()));
		}
		
		return deleteResult > 0;
	}
	
	private static String cloneTemplateCode(String tmpCode){
		if(!")".equals(String.valueOf(tmpCode.charAt(tmpCode.length() - 1)))){
			return tmpCode + "(1)";
		}
		
		int idx = 0;
		for (int i = 2; i < tmpCode.length() + 1; i++) {
			if("(".equals(String.valueOf(tmpCode.charAt(tmpCode.length() - i)))){
				idx = tmpCode.length() - i + 1;
				break;
			}
		}
		
		String subFix = tmpCode.substring(idx, tmpCode.length() - 1);
		
		try {
			int subFixNum = Integer.valueOf(subFix);
			subFixNum += 1;
			return tmpCode.substring(0, idx-1) + "(" + subFixNum + ")";
		} catch (Exception e) {
			return tmpCode + "(1)";
		}
	}
	
}
