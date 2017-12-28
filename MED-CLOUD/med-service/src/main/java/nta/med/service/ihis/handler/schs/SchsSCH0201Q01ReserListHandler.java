package nta.med.service.ihis.handler.schs;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.sch.Sch0201Repository;
import nta.med.data.model.ihis.schs.SchsSCH0201Q01ReserListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SchsModelProto;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.ihis.proto.SchsServiceProto.SchsSCH0201Q01ReserListRequest;
import nta.med.service.ihis.proto.SchsServiceProto.SchsSCH0201Q01ReserListResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class SchsSCH0201Q01ReserListHandler	
	extends ScreenHandler<SchsServiceProto.SchsSCH0201Q01ReserListRequest, SchsServiceProto.SchsSCH0201Q01ReserListResponse> {
	@Resource
	private Sch0201Repository sch0201Repository;
	@Override
	@Transactional(readOnly=true)
	public SchsSCH0201Q01ReserListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
		SchsSCH0201Q01ReserListRequest request) throws Exception {
		String hospCode = getHospitalCode(vertx, sessionId);
		List<SchsSCH0201Q01ReserListItemInfo> listResult = sch0201Repository.getSchsSCH0201Q01ReserListItemInfo(hospCode, request.getFromDate(),
        		request.getToDate(),request.getJundalTable(), request.getJundalPart(), request.getChecked()); 
        SchsServiceProto.SchsSCH0201Q01ReserListResponse.Builder  response =  SchsServiceProto.SchsSCH0201Q01ReserListResponse.newBuilder();
        if(listResult != null  && !listResult.isEmpty()){
        	for(SchsSCH0201Q01ReserListItemInfo item :listResult ){
        		SchsModelProto.SchsSCH0201Q01ReserListItemInfo.Builder info = SchsModelProto.SchsSCH0201Q01ReserListItemInfo.newBuilder();
        		
        		if (!StringUtils.isEmpty(item.getPksch0201())) {
        			info.setPksch0201(item.getPksch0201());
        		}
        		if (!StringUtils.isEmpty(item.getInOutGubun())) {
        			info.setInOutGubun(item.getInOutGubun());
        		}
        		if (!StringUtils.isEmpty(item.getFkocs())) {
        			info.setFkocs(item.getFkocs());
        		}
        		if (!StringUtils.isEmpty(item.getBunho())) {
        			info.setBunho(item.getBunho());
        		}
        		if (!StringUtils.isEmpty(item.getGwa())) {
        			info.setGwa(item.getGwa());
        		}
        		if (!StringUtils.isEmpty(item.getGumsaja())) {
        			info.setGumsaja(item.getGumsaja());
        		}
        		if (!StringUtils.isEmpty(item.getHangmogCode())) {
        			info.setHangmogCode(item.getHangmogCode());
        		}
        		if (!StringUtils.isEmpty(item.getJundalTable())) {
        			info.setJundalTable(item.getJundalTable());
        		}
        		if (!StringUtils.isEmpty(item.getJundalPart())) {
        			info.setJundalPart(item.getJundalPart());
        		}
        		if (!StringUtils.isEmpty(item.getReserDate())) {
        			info.setReserDate(item.getReserDate());
        		}
        		if (!StringUtils.isEmpty(item.getReserTime())) {
        			info.setReserTime(item.getReserTime());
        		}
        		if (!StringUtils.isEmpty(item.getInputDate())) {
        			info.setInputDate(item.getInputDate());
        		}
        		if (!StringUtils.isEmpty(item.getInputId())) {
        			info.setInputId(item.getInputId());
        		}
        		if (!StringUtils.isEmpty(item.getSuname())) {
        			info.setSuname(item.getSuname());
        		}
        		if (!StringUtils.isEmpty(item.getReserYn())) {
        			info.setReserYn(item.getReserYn());
        		}
        		if (!StringUtils.isEmpty(item.getCancelYn())) {
        			info.setCancelYn(item.getCancelYn());
        		}
        		if (!StringUtils.isEmpty(item.getActingDate())) {
        			info.setActingDate(item.getActingDate());
        		}
        		if (!StringUtils.isEmpty(item.getHopeDate())) {
        			info.setHopeDate(item.getHopeDate());
        		}
        		if (!StringUtils.isEmpty(item.getComments())) {
        			info.setComments(item.getComments());
        		}
        		if (!StringUtils.isEmpty(item.getHangmogName())) {
        			info.setHangmogName(item.getHangmogName());
        		}
        		if (!StringUtils.isEmpty(item.getJundalPartName())) {
        			info.setJundalPartName(item.getJundalPartName());
        		}
        		if (!StringUtils.isEmpty(item.getGwaName())) {
        			info.setGwaName(item.getGwaName());
        		}
        		if (!StringUtils.isEmpty(item.getHoDong1())) {
        			info.setHoDong1(item.getHoDong1());
        		}
        		if (!StringUtils.isEmpty(item.getSex())) {
        			info.setSex(item.getSex());
        		}
        		if (!StringUtils.isEmpty(item.getAge())) {
        			info.setAge(item.getAge().toString());
        		}
        		if (!StringUtils.isEmpty(item.getBirth())) {
        			info.setBirth(item.getBirth().toString());
        		}
        		if (!StringUtils.isEmpty(item.getInputGwa())) {
        			info.setInputGwa(item.getInputGwa());
        		}
        		if (!StringUtils.isEmpty(item.getDoctorName())) {
        			info.setDoctorName(item.getDoctorName());
        		}
        		if (!StringUtils.isEmpty(item.getUpdName())) {
        			info.setUpdName(item.getUpdName());
        		}
        		if (!StringUtils.isEmpty(item.getPortableYn())) {
        			info.setPortableYn(item.getPortableYn());
        		}
        		
        		response.addReserListItem(info);
        	}
        }
		return response.build();
	}
}
