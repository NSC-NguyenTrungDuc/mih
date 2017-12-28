package nta.med.service.emr.handler;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import javax.annotation.Resource;

import org.apache.commons.lang.StringUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.glossary.CommonEnum;
import nta.med.core.glossary.TrialFlg;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.emr.EmrTagRepository;
import nta.med.data.dao.emr.EmrTemplateRepository;
import nta.med.data.model.ihis.emr.OCS2015U09EmrTagGetTemplateTagsInfo;
import nta.med.data.model.ihis.emr.OCS2015U09GetTemplateComboBoxInfo;
import nta.med.service.emr.proto.EmrModelProto;
import nta.med.service.emr.proto.EmrServiceProto;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS2015U09GetTemplateComboBoxHandler extends ScreenHandler<EmrServiceProto.OCS2015U09GetTemplateComboBoxRequest, EmrServiceProto.OCS2015U09GetTemplateComboBoxResponse> {
	private static final Log LOGGER = LogFactory.getLog(OCS2015U09GetTemplateComboBoxHandler.class);                                    
	@Resource                                                                                                       
	private EmrTemplateRepository emrTemplateRepository;
	@Resource                                                                                                       
	private EmrTagRepository emrTagRepository;

	@Override
	@Transactional(readOnly = true)
	public EmrServiceProto.OCS2015U09GetTemplateComboBoxResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, EmrServiceProto.OCS2015U09GetTemplateComboBoxRequest request) throws Exception {

		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		EmrServiceProto.OCS2015U09GetTemplateComboBoxResponse.Builder response = EmrServiceProto.OCS2015U09GetTemplateComboBoxResponse.newBuilder();
		List<OCS2015U09GetTemplateComboBoxInfo> list = emrTemplateRepository.getOCS2015U09GetTemplateComboBoxInfo(hospCode, getUserId(vertx, sessionId), language);
		
		// get List emrTemplateId
		List<Integer> listEmrTemplateId = new ArrayList<Integer>();
		if(!CollectionUtils.isEmpty(list)){
			for(OCS2015U09GetTemplateComboBoxInfo item : list){
				if(item.getTemplateId() != null) {
					listEmrTemplateId.add(item.getTemplateId());
				}
			}
		}
		
		List<OCS2015U09EmrTagGetTemplateTagsInfo> listTag =  emrTagRepository.getOCS2015U09EmrTagGetTemplateTagsInfo(hospCode, listEmrTemplateId);
		Map<Integer, Map<String, OCS2015U09EmrTagGetTemplateTagsInfo>> mapTagInfo = new HashMap<>();
		if(!CollectionUtils.isEmpty(listTag)){
			for(OCS2015U09EmrTagGetTemplateTagsInfo item : listTag){
				if(!mapTagInfo.containsKey(item.getEmrTemplateId())) mapTagInfo.putIfAbsent(item.getEmrTemplateId(), new HashMap<>());
				Map<String, OCS2015U09EmrTagGetTemplateTagsInfo> subMap = mapTagInfo.get(item.getEmrTemplateId());
				String key = String.format("%s%s", item.getTagParent().trim(), item.getTagChild() == null ? "" : item.getTagChild());
				subMap.put(key, item);
			}
		}
		
		if(!CollectionUtils.isEmpty(list)){
			for(OCS2015U09GetTemplateComboBoxInfo item : list){
				EmrModelProto.OCS2015U09GetTemplateComboBoxInfo.Builder info = EmrModelProto.OCS2015U09GetTemplateComboBoxInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				if (item.getTemplateId() != null) {
					info.setEmrTemplateId(item.getTemplateId().toString());
				}
				if (item.getTemplateTypeId() != null) {
					info.setEmrTemplateTypeId(item.getTemplateTypeId().toString());
				}
				
				if(CommonEnum.S.getValue().equalsIgnoreCase(item.getPermissionType()) && TrialFlg.YES.getValue().equalsIgnoreCase(item.getDefaultFlg())){
					for(OCS2015U09GetTemplateComboBoxInfo item2 : list){
						if(!CommonEnum.S.getValue().equalsIgnoreCase(item2.getPermissionType()) && TrialFlg.YES.getValue().equalsIgnoreCase(item2.getDefaultFlg())){
							info.setDefaultYn(TrialFlg.NO.getValue());
							break;
						}else{
							if(item.getDefaultFlg() != null){
								info.setDefaultYn(item.getDefaultFlg());
							}
						}
					}	
				}else{
					if(item.getDefaultFlg() != null){
						info.setDefaultYn(item.getDefaultFlg());
					}
				}

				if(!CollectionUtils.isEmpty(listTag)){
					List<String> tags = new ArrayList<String>();
					List<String> compositeTags = new ArrayList<String>();
					for(OCS2015U09EmrTagGetTemplateTagsInfo tag : listTag){						
						if(item.getTemplateId().intValue() == tag.getEmrTemplateId().intValue()){
							compositeTags.add(String.format("%s%s", tag.getTagParent().trim(), tag.getTagChild() == null ? "" : tag.getTagChild()));
							if(!StringUtils.isEmpty(tag.getTagParent()) && StringUtils.isEmpty(tag.getTagChild())) {
								tags.add(tag.getTagParent());
							}else if(!StringUtils.isEmpty(tag.getTagParent()) && !StringUtils.isEmpty(tag.getTagChild())) {
								tags.add(tag.getTagChild());
							}
						}
					}
					for (int i = 0; i < compositeTags.size() ; i++) {
						EmrModelProto.OCS2015U31EmrTagGetTemplateTagsInfo.Builder tagInfo = EmrModelProto.OCS2015U31EmrTagGetTemplateTagsInfo.newBuilder();
						if(mapTagInfo.get(item.getTemplateId()) != null && mapTagInfo.get(item.getTemplateId()).get(compositeTags.get(i)) != null){
					       BeanUtils.copyProperties(mapTagInfo.get(item.getTemplateId()).get(compositeTags.get(i)), tagInfo, getLanguage(vertx, sessionId));
					    }
						info.addTags(tagInfo);
					}
					if(!CollectionUtils.isEmpty(tags)){
						info.setTemplateContent(StringUtils.join(tags,","));
					}
				}
				response.addTemplateList(info);
			}
		}
				
		return response.build();
	}
}