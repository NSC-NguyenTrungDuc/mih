package nta.med.service.ihis.handler.schs;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.sch.Sch0109Repository;
import nta.med.data.model.ihis.schs.ComboGumsaListItemInfo;
import nta.med.data.model.ihis.schs.ComboGumsaPartListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SchsModelProto;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.ihis.proto.SchsServiceProto.SchsSCH0201U99CommonDataRequest;
import nta.med.service.ihis.proto.SchsServiceProto.SchsSCH0201U99CommonDataResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class SchsSCH0201U99CommonDataHandler	
	extends ScreenHandler<SchsServiceProto.SchsSCH0201U99CommonDataRequest, SchsServiceProto.SchsSCH0201U99CommonDataResponse> {
	@Resource
	private Sch0109Repository sch0109Repository;
	@Override
	@Transactional(readOnly=true)
	public SchsSCH0201U99CommonDataResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			SchsSCH0201U99CommonDataRequest request) throws Exception {
	     SchsServiceProto.SchsSCH0201U99CommonDataResponse.Builder  response =  SchsServiceProto.SchsSCH0201U99CommonDataResponse.newBuilder();
	     String hospCode = getHospitalCode(vertx, sessionId);
	     List<ComboGumsaListItemInfo> listComboGumsaListItem = sch0109Repository.getComboGumsaListItemInfo(hospCode);
	     
	     if(listComboGumsaListItem != null && !listComboGumsaListItem.isEmpty()){
	    	 for(ComboGumsaListItemInfo item : listComboGumsaListItem){
	    		 SchsModelProto.ComboGumsaListItemInfo.Builder info = SchsModelProto.ComboGumsaListItemInfo.newBuilder();
	    		 if (!StringUtils.isEmpty(item.getCode())) {
	    				info.setCode(item.getCode());
	    		    }
	    		if (!StringUtils.isEmpty(item.getCodeName())) {
	    				info.setCodeName(item.getCodeName());
	    			}
	    		if (!StringUtils.isEmpty(item.getSeq())) {
    				info.setSeq(item.getSeq().toString());
    			}
	    		response.addComboList1(info);
	    	 }
	     }
	     
	     List<ComboGumsaPartListItemInfo> listComboGumsaPartListItemInfo = sch0109Repository.getComboGumsaPartListItemInfo(hospCode,request.getJundalTable());
	     
	     if(listComboGumsaPartListItemInfo != null && !listComboGumsaPartListItemInfo.isEmpty()){
	    	 for(ComboGumsaPartListItemInfo item : listComboGumsaPartListItemInfo){
	    		 SchsModelProto.ComboGumsaPartListItemInfo.Builder info = SchsModelProto.ComboGumsaPartListItemInfo.newBuilder();
	    		 if (!StringUtils.isEmpty(item.getCode())) {
	    				info.setCode(item.getCode());
	    		    }
	    		if (!StringUtils.isEmpty(item.getCodeName())) {
	    				info.setCodeName(item.getCodeName());
	    			}
	    		response.addComboList2(info);
	    	 }
	     }
	     return response.build();
	}
}
