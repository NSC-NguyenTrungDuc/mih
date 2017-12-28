package nta.med.service.ihis.handler.nuro;

import java.util.ArrayList;
import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.data.model.ihis.system.TripleListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OUT0101U02ComboListHandler extends ScreenHandler<NuroServiceProto.OUT0101U02ComboListRequest, NuroServiceProto.OUT0101U02ComboListResponse> {                             
	private static final Log LOG = LogFactory.getLog(OUT0101U02ComboListHandler.class);                                        
	@Resource
    private Bas0102Repository bas0102Repository;

	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.OUT0101U02ComboListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.OUT0101U02ComboListRequest request) throws Exception {
		NuroServiceProto.OUT0101U02ComboListResponse.Builder response = NuroServiceProto.OUT0101U02ComboListResponse.newBuilder();
		List<String> listCodeType = new ArrayList<String>();
    	listCodeType.add(request.getSexCodeType());
    	listCodeType.add(request.getBunhoCodeType());
    	listCodeType.add(request.getTelCodeType());
    	listCodeType.add(request.getBoninCodeType());
    	listCodeType.add(request.getBillingCodeType());
    	List<TripleListItemInfo> listItem = bas0102Repository.getByCodeTypeList(getLanguage(vertx, sessionId), getHospitalCode(vertx, sessionId), listCodeType, true);
    	if (!CollectionUtils.isEmpty(listItem)) {
    		for (TripleListItemInfo item : listItem) {
    			CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
    			info.setCode(item.getItem1());
    			info.setCodeName(item.getItem2());
    			if(request.getSexCodeType().equalsIgnoreCase(item.getItem3())) {
    				response.addSexComboListItem(info);
    			}
    			if(request.getBunhoCodeType().equalsIgnoreCase(item.getItem3())) {
    				response.addBunhoComboListItem(info);
    			}
    			if(request.getTelCodeType().equalsIgnoreCase(item.getItem3())) {
    				response.addTelComboListItem(info);
    			}
    			if(request.getBoninCodeType().equalsIgnoreCase(item.getItem3())) {
    				response.addBoninComboListItem(info);
    			}
    			if(request.getBillingCodeType().equalsIgnoreCase(item.getItem3())) {
    				response.addBillingCodeType(info);
    			}
    		}
    	}
		return response.build();
	}
}                                                                                                                 
