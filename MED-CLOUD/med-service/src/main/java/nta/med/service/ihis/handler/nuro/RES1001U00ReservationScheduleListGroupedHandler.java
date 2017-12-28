package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.res.Res0102Repository;
import nta.med.data.dao.medi.res.Res0103Repository;
import nta.med.data.dao.medi.res.Res0106Repository;
import nta.med.data.model.ihis.nuro.NuroRES1001U00AverageTimeListItemInfo;
import nta.med.data.model.ihis.nuro.NuroRES1001U00ReservationScheduleConditionListItemInfo;
import nta.med.data.model.ihis.nuro.NuroRES1001U00ReservationScheduleListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.apache.commons.lang3.StringUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class RES1001U00ReservationScheduleListGroupedHandler  extends ScreenHandler<NuroServiceProto.RES1001U00ReservationScheduleListGroupedRequest, NuroServiceProto.RES1001U00ReservationScheduleListGroupedResponse> {
	private static final Log LOG = LogFactory.getLog(RES1001U00ReservationScheduleListGroupedHandler.class);
	
	@Resource
	private Res0102Repository res0102Repository;
	
	@Resource
	private Res0103Repository res0103Repository;
	
	@Resource
	private Res0106Repository res0106Repository;

	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.RES1001U00ReservationScheduleListGroupedResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.RES1001U00ReservationScheduleListGroupedRequest request) throws Exception {
		NuroServiceProto.RES1001U00ReservationScheduleListGroupedResponse.Builder response = NuroServiceProto.RES1001U00ReservationScheduleListGroupedResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		if(!StringUtils.isEmpty(request.getHospCodeLink())){
			hospCode = request.getHospCodeLink();
		}
		List<NuroRES1001U00ReservationScheduleConditionListItemInfo> listReservationScheduleCondition = res0103Repository.getReservationScheduleConditionListItemInfo(hospCode, request.getDoctorCode(), request.getExamPreDate());
    	if (listReservationScheduleCondition != null && !listReservationScheduleCondition.isEmpty()) {
        	 for (NuroRES1001U00ReservationScheduleConditionListItemInfo item : listReservationScheduleCondition) {
             	NuroModelProto.NuroRES1001U00ReservationScheduleConditionListItemInfo.Builder info = NuroModelProto.NuroRES1001U00ReservationScheduleConditionListItemInfo.newBuilder();
             	if(!StringUtils.isEmpty(item.getAmStartTime()))  {
             		info.setAmStartTime(item.getAmStartTime());
             	}
             	if(!StringUtils.isEmpty(item.getAmEndTime()))  {
             		info.setAmEndTime(item.getAmEndTime());
             	}
             	if(!StringUtils.isEmpty(item.getPmStartTime()))  {
             		info.setPmStartTime(item.getPmStartTime());
             	}
             	if(!StringUtils.isEmpty(item.getPmEndTime()))  {
             		info.setPmEndTime(item.getPmEndTime());
             	}
             	response.addResScheduleConditionListItem(info);
             }
        }else{
        	listReservationScheduleCondition = res0102Repository.getNuroReservationScheduleConditionList(hospCode, request.getExamPreDate(), request.getDoctorCode());
            if (listReservationScheduleCondition != null && !listReservationScheduleCondition.isEmpty()) {
                for (NuroRES1001U00ReservationScheduleConditionListItemInfo item : listReservationScheduleCondition) {
                	NuroModelProto.NuroRES1001U00ReservationScheduleConditionListItemInfo.Builder info = NuroModelProto.NuroRES1001U00ReservationScheduleConditionListItemInfo.newBuilder();
                 	if(!StringUtils.isEmpty(item.getAmStartTime()))  {
                 		info.setAmStartTime(item.getAmStartTime());
                 	}
                 	if(!StringUtils.isEmpty(item.getAmEndTime()))  {
                 		info.setAmEndTime(item.getAmEndTime());
                 	}
                 	if(!StringUtils.isEmpty(item.getPmStartTime()))  {
                 		info.setPmStartTime(item.getPmStartTime());
                 	}
                 	if(!StringUtils.isEmpty(item.getPmEndTime()))  {
                 		info.setPmEndTime(item.getPmEndTime());
                 	}
                 	response.addResScheduleConditionListItem(info);
                }
            }
        }
    	
    	List<NuroRES1001U00AverageTimeListItemInfo > listAverageTime = res0102Repository.getAverageTimeList(hospCode, request.getExamPreDate(), request.getDoctorCode());
    	if (listAverageTime != null && !listAverageTime.isEmpty()) {
            for (NuroRES1001U00AverageTimeListItemInfo item : listAverageTime) {
            	NuroModelProto.NuroRES1001U00AverageTimeListItemInfo.Builder info = NuroModelProto.NuroRES1001U00AverageTimeListItemInfo.newBuilder();
             	if(item.getAvgTime() != null)  {
             		info.setAvgTime(String.format("%.0f", item.getAvgTime()));
             	}
             	if(item.getDocResLimit() != null)  {
             		info.setDocResLimit(String.format("%.0f", item.getDocResLimit()));
             	}
             	response.addAvgTimeListItem(info);
            }
        }
    	 
    	 String avgTime = "";
    	 if(listAverageTime != null && !listAverageTime.isEmpty()){
    		 avgTime = listAverageTime.get(0).getAvgTime().toString();
    	}
    	 String amStart = null; String amEnd = null; String pmStart = null; String pmEnd = null;
    	 if(!CollectionUtils.isEmpty(listReservationScheduleCondition)){
    		  amStart =listReservationScheduleCondition.get(0).getAmStartTime();
        	  amEnd=listReservationScheduleCondition.get(0).getAmEndTime();
        	  pmStart =listReservationScheduleCondition.get(0).getPmStartTime();
        	  pmEnd =listReservationScheduleCondition.get(0).getPmEndTime();
    	 }
    	 
    	List<NuroRES1001U00ReservationScheduleListItemInfo> listReservationScheduleAm = res0106Repository.getReservationScheduleList(hospCode, request.getExamPreDate(), 
        		request.getDepartmentCode(), request.getDoctorCode(), amStart, amEnd, avgTime);
    	if (listReservationScheduleAm != null && !listReservationScheduleAm.isEmpty()) {
            for (NuroRES1001U00ReservationScheduleListItemInfo  item : listReservationScheduleAm) {
            	NuroModelProto.NuroRES1001U00ReservationScheduleListItemInfo.Builder info = NuroModelProto.NuroRES1001U00ReservationScheduleListItemInfo.newBuilder();
            	BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                response.addResScheduleAmListItem(info);
            }
        }
    	
    	List<NuroRES1001U00ReservationScheduleListItemInfo> listReservationSchedulePm = res0106Repository.getReservationScheduleList(hospCode, request.getExamPreDate(), 
        		request.getDepartmentCode(), request.getDoctorCode(),pmStart, pmEnd, avgTime);
    	if (listReservationSchedulePm != null && !listReservationSchedulePm.isEmpty()) {
            for (NuroRES1001U00ReservationScheduleListItemInfo  item : listReservationSchedulePm) {
            	NuroModelProto.NuroRES1001U00ReservationScheduleListItemInfo.Builder info = NuroModelProto.NuroRES1001U00ReservationScheduleListItemInfo.newBuilder();
            	BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                response.addResSchedulePmListItem(info);
            }
        }
		return response.build();
	}
}
