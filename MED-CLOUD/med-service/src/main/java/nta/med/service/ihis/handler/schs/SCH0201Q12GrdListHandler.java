package nta.med.service.ihis.handler.schs;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.sch.Sch0201Repository;
import nta.med.data.model.ihis.schs.SCH0201Q12GrdListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SchsModelProto;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.ihis.proto.SchsServiceProto.SCH0201Q12GrdListRequest;
import nta.med.service.ihis.proto.SchsServiceProto.SCH0201Q12GrdListResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class SCH0201Q12GrdListHandler
	extends ScreenHandler<SchsServiceProto.SCH0201Q12GrdListRequest, SchsServiceProto.SCH0201Q12GrdListResponse>{
	@Resource
	private Sch0201Repository sch0201Repository;
	@Override
	@Transactional(readOnly=true)
	public SCH0201Q12GrdListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, SCH0201Q12GrdListRequest request)
			throws Exception {
		List<SCH0201Q12GrdListItemInfo> listResult = sch0201Repository.getSCH0201Q12GrdListItemInfo(getHospitalCode(vertx, sessionId),
	    		 request.getBunho(),request.getStatFlg(),request.getNaewonDate(),request.getGwa(),request.getDoctor(),request.getReserGubun(), getLanguage(vertx, sessionId));
	     SchsServiceProto.SCH0201Q12GrdListResponse.Builder  response =  SchsServiceProto.SCH0201Q12GrdListResponse.newBuilder();
	     if(listResult!= null && !listResult.isEmpty()){
	    	 for(SCH0201Q12GrdListItemInfo item : listResult){
	    		 SchsModelProto.SCH0201Q12GrdListItemInfo.Builder info = SchsModelProto.SCH0201Q12GrdListItemInfo.newBuilder();
	    		if (!StringUtils.isEmpty(item.getKizyunDate())) {
	    				info.setKizyunDate(item.getKizyunDate().toString());
    			}
    			if (!StringUtils.isEmpty(item.getGwa())) {
    				info.setGwa(item.getGwa());
    			}
    			if (!StringUtils.isEmpty(item.getGwaName())) {
    				info.setGwaName(item.getGwaName());
    			}
    			if (!StringUtils.isEmpty(item.getDoctor())) {
    				info.setDoctor(item.getDoctor());
    			}
    			if (!StringUtils.isEmpty(item.getDoctorName())) {
    				info.setDoctorName(item.getDoctorName());
    			}
    			if (!StringUtils.isEmpty(item.getHangmogCode())) {
    				info.setHangmogCode(item.getHangmogCode());
    			}
    			if (!StringUtils.isEmpty(item.getHangmogName())) {
    				info.setHangmogName(item.getHangmogName());
    			}
    			if (!StringUtils.isEmpty(item.getJundalTable())) {
    				info.setJundalTable(item.getJundalTable());
    			}
    			if (!StringUtils.isEmpty(item.getJundalPart())) {
    				info.setJundalPart(item.getJundalPart());
    			}
    			if (!StringUtils.isEmpty(item.getJundalPartName())) {
    				info.setJundalPartName(item.getJundalPartName());
    			}
    			if (!StringUtils.isEmpty(item.getReserTime())) {
    				info.setReserTime(item.getReserTime());
    			}
    			if (!StringUtils.isEmpty(item.getReserYn())) {
    				info.setReserYn(item.getReserYn());
    			}
    			if (!StringUtils.isEmpty(item.getActYn())) {
    				info.setActYn(item.getActYn());
    			}
    			if (!StringUtils.isEmpty(item.getOrderDate())) {
    				info.setOrderDate(item.getOrderDate().toString());
    			}
    			if (!StringUtils.isEmpty(item.getPksch())) {
    				info.setPksch(item.getPksch().toString());
    			}
    			response.addGrdListItem(info);
	    	 }
	     }
	     return response.build();
	}
}
