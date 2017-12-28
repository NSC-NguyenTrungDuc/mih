package nta.med.service.ihis.handler.schs;

import java.util.ArrayList;
import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.lang.StringUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.data.model.ihis.schs.SCH0201U99BookingDetailInfo;
import nta.med.service.ihis.proto.SchsModelProto;
import nta.med.service.ihis.proto.SchsModelProto.SCH0201U99EMRLinkInfo;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.ihis.proto.SchsServiceProto.SCH0201U99BookingDetailRequest;
import nta.med.service.ihis.proto.SchsServiceProto.SCH0201U99BookingDetailResponse;

@Service
@Scope("prototype")
public class SCH0201U99BookingDetailHandler extends ScreenHandler<SchsServiceProto.SCH0201U99BookingDetailRequest, SchsServiceProto.SCH0201U99BookingDetailResponse> {
	
	private static final Log LOG = LogFactory.getLog(SCH0201U99BookingDetailHandler.class);
	@Resource
	private Out0101Repository out0101Repository;

	@Override
	@Transactional(readOnly = true)
	public SCH0201U99BookingDetailResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			SCH0201U99BookingDetailRequest request) throws Exception {
		SchsServiceProto.SCH0201U99BookingDetailResponse.Builder response = SchsServiceProto.SCH0201U99BookingDetailResponse.newBuilder(); 
		String hospCode = getHospitalCode(vertx, sessionId);
		List<String> bunho = new ArrayList<String>();
		List<String> hospCodeLink = new ArrayList<String>();
		for(SCH0201U99EMRLinkInfo item : request.getEmrLinkItemList()){
			bunho.add(item.getBunho());
			if(!StringUtils.isEmpty(item.getHospCodeLink()) && !item.getHospCodeLink().equalsIgnoreCase(hospCode)){
				hospCodeLink.add(item.getHospCodeLink());
			}
		}
		if(CollectionUtils.isEmpty(bunho)){
			bunho.add("");
		}
		if(CollectionUtils.isEmpty(hospCodeLink)){
			hospCodeLink.add("");
		}
		List<SCH0201U99BookingDetailInfo> listBooking = out0101Repository.getSCH0201U99BookingDetailInfo(hospCode, getLanguage(vertx, sessionId), request.getReservation(),
				request.getJundalTable(), request.getJundalPart(), DateUtil.toDate(request.getReserDate(), DateUtil.PATTERN_YYMMDD) , bunho, hospCodeLink);
		if(!CollectionUtils.isEmpty(listBooking)){
			for(SCH0201U99BookingDetailInfo item : listBooking){
				SchsModelProto.SCH0201U99BookingDetailInfo.Builder info = SchsModelProto.SCH0201U99BookingDetailInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addDetailInfo(info);
			}
		}
		return response.build();
	}

}
