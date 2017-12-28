package nta.med.service.ihis.handler.schs;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.sch.Sch0002Repository;
import nta.med.data.dao.medi.sch.Sch0201Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.ihis.proto.SchsServiceProto.SchsSCH0201Q01GumsaComboListRequest;
import nta.med.service.ihis.proto.SchsServiceProto.SchsSCH0201Q01GumsaComboListResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")   
@Transactional
public class SchsSCH0201Q01GumsaComboListHandler
	extends ScreenHandler<SchsServiceProto.SchsSCH0201Q01GumsaComboListRequest, SchsServiceProto.SchsSCH0201Q01GumsaComboListResponse>{
	@Resource
	private Sch0201Repository sch0201Repository;
	@Resource
	private Sch0002Repository sch0002Repository;
	@Override
	@Transactional(readOnly=true)
	public SchsSCH0201Q01GumsaComboListResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			SchsSCH0201Q01GumsaComboListRequest request) throws Exception {
         SchsServiceProto.SchsSCH0201Q01GumsaComboListResponse.Builder response =  SchsServiceProto.SchsSCH0201Q01GumsaComboListResponse.newBuilder();
         String hospCode = getHospitalCode(vertx, sessionId);
         String language = getLanguage(vertx, sessionId);
    	 List<ComboListItemInfo> listResult = sch0201Repository.getSchsSCH0201Q01SCH0109ComboList(hospCode, language);
         if(listResult != null  && !listResult.isEmpty()){
         	for(ComboListItemInfo item : listResult){
         		CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
         		if (!StringUtils.isEmpty(item.getCode())) {
             		info.setCode(item.getCode());
             	}
             	if (item.getCodeName() != null) {
             		info.setCodeName(item.getCodeName());
             	}
             	response.addGumsaComboItem(info);
         	}
         }
         if(request.getHangmogCode()!=null && !request.getHangmogCode().isEmpty()){
        	 String jundalTable=sch0002Repository.getjundalTable(hospCode,request.getHangmogCode());
        	 if(!StringUtils.isEmpty(jundalTable)){
        		 response.setSelectedValue(jundalTable);
        	 }
         }
         return response.build();
	}
}
