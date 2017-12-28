package nta.med.service.ihis.handler.cpls;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.cpl.Cpl2010Repository;
import nta.med.data.dao.medi.cpl.Cpl2090Repository;
import nta.med.data.model.ihis.cpls.CPL3020U00DsvNoteListItemInfo;
import nta.med.data.model.ihis.cpls.CPL3020U02GetSpecimenInfoSelectListItemInfo;
import nta.med.data.model.ihis.cpls.PrCplSpecimenInfoResultListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3020U00GrdPaRowFocusChangedRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3020U00GrdPaRowFocusChangedResponse;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class CPL3020U00GrdPaRowFocusChangedHandler extends ScreenHandler<CplsServiceProto.CPL3020U00GrdPaRowFocusChangedRequest, CplsServiceProto.CPL3020U00GrdPaRowFocusChangedResponse>{
	@Resource
	private Cpl2010Repository cpl2010Repository;
	
	@Resource
	private CommonRepository commonRepository;
	
	@Resource
	private Cpl2090Repository cpl2090Repository;
	
	@Override
	@Transactional
	public CPL3020U00GrdPaRowFocusChangedResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			CPL3020U00GrdPaRowFocusChangedRequest request) throws Exception {
        CplsServiceProto.CPL3020U00GrdPaRowFocusChangedResponse.Builder response = CplsServiceProto.CPL3020U00GrdPaRowFocusChangedResponse.newBuilder();
        String hospCode = getHospitalCode(vertx, sessionId);
        String language = getLanguage(vertx, sessionId);
    	//1.
    	PrCplSpecimenInfoResultListItemInfo item = cpl2010Repository.prCplSpecimenInfoResult(hospCode, request.getSpecimentSer());
        CplsModelProto.CPL3020U00CplSpecimenInfo.Builder info = CplsModelProto.CPL3020U00CplSpecimenInfo.newBuilder();
        if(info != null){
        	BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
            response.addCplSpecimenItem(info);
            
            //2.
            String orderDate = DateUtil.toString(item.getOrderDate(), DateUtil.PATTERN_YYMMDD);
            List<CPL3020U02GetSpecimenInfoSelectListItemInfo> listSpecimenInfoItem = commonRepository.getCPL3020U02GetSpecimenInfoSelectListItemInfo(hospCode, language, item.getGwa(), item.getHoDong(), orderDate);
            if(!CollectionUtils.isEmpty(listSpecimenInfoItem)) {
            	for(CPL3020U02GetSpecimenInfoSelectListItemInfo specimenInfoItem : listSpecimenInfoItem) {
            		response.setGwaName(specimenInfoItem.getGwaName());
            		response.setHoDongName(specimenInfoItem.getHoDongName());
            	}
            }
        }
       
        //3.
        List<CPL3020U00DsvNoteListItemInfo> listCPL3020U00DsvNoteListItem = cpl2090Repository.getCPL3020U00DsvNoteListItem(hospCode, request.getSpecimenSer(), request.getJundalGubun());
    	if(listCPL3020U00DsvNoteListItem != null && !listCPL3020U00DsvNoteListItem.isEmpty()){
    		for(CPL3020U00DsvNoteListItemInfo dsvNoteListItem : listCPL3020U00DsvNoteListItem){
    			CplsModelProto.CPL3020U00DsvNoteListItemInfo.Builder dsvNoteListItemInfo = CplsModelProto.CPL3020U00DsvNoteListItemInfo.newBuilder();
    			BeanUtils.copyProperties(dsvNoteListItem, dsvNoteListItemInfo, getLanguage(vertx, sessionId));
    			response.addDsvNoteItem(dsvNoteListItemInfo);
    		}
    	}
    	return response.build();
	}
}
