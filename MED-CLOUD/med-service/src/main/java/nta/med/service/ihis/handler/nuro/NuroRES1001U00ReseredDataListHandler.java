package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.data.model.ihis.nuro.NuroRES1001U00ReseredDataListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class NuroRES1001U00ReseredDataListHandler extends ScreenHandler<NuroServiceProto.NuroRES1001U00ReseredDataListRequest, NuroServiceProto.NuroRES1001U00ReseredDataListResponse> {
	private static final Log LOGGER = LogFactory.getLog(NuroRES1001U00ReseredDataListHandler.class);
	@Resource
	private Out1001Repository out1001Repository;

    @Override
	public boolean isValid(NuroServiceProto.NuroRES1001U00ReseredDataListRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getExamPreDate()) && DateUtil.toDate(request.getExamPreDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}

	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.NuroRES1001U00ReseredDataListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroRES1001U00ReseredDataListRequest request) throws Exception {
		NuroServiceProto.NuroRES1001U00ReseredDataListResponse.Builder response = NuroServiceProto.NuroRES1001U00ReseredDataListResponse.newBuilder();
		String sessionHospCode = getHospitalCode(vertx, sessionId);
		String hospCode = getHospitalCode(vertx, sessionId);
		boolean isOtherTab = false; 
		if(!StringUtils.isEmpty(request.getHospCodeLink())){
			hospCode = request.getHospCodeLink();
			isOtherTab = true;
		}
		List<NuroRES1001U00ReseredDataListItemInfo> listObject = out1001Repository.getNuroRES1001U00ReseredDataListItemInfo(hospCode, sessionHospCode,
        		request.getDepartmentCode(), request.getDoctorCode(), request.getExamPreDate(), request.getFromTime(), 
        		request.getToTime(), request.getReserToTime(), isOtherTab);
        if (listObject != null && !listObject.isEmpty()) {
        	 for (NuroRES1001U00ReseredDataListItemInfo item : listObject) {
             	NuroModelProto.NuroRES1001U00ReseredDataListItemInfo.Builder info = NuroModelProto.NuroRES1001U00ReseredDataListItemInfo.newBuilder();
             	if(!StringUtils.isEmpty(item.getReceptionTime()))  {
             		info.setReceptionTime(item.getReceptionTime());
             	}
             	if(!StringUtils.isEmpty(item.getPatientCode()))  {
             		info.setPatientCode(item.getPatientCode());
             	}
             	if(!StringUtils.isEmpty(item.getPatientName1()))  {
             		info.setPatientName1(item.getPatientName1());
             	}
             	if(!StringUtils.isEmpty(item.getPatientName2()))  {
             		info.setPatientName2(item.getPatientName2());
             	}
             	if(!StringUtils.isEmpty(item.getExamStatus()))  {
             		info.setExamStatus(item.getExamStatus());
             	}
             	if(!StringUtils.isEmpty(item.getUpdDate()))  {
             		info.setUpdDate(item.getUpdDate());
             	}
             	if(item.getPkout1001() != null)  {
             		info.setPkout1001(item.getPkout1001().toString());
             	}
             	if(item.getComingDate() != null)  {
             		info.setComingDate(DateUtil.toString(item.getComingDate(), DateUtil.PATTERN_YYMMDD));
             	}
             	if(!StringUtils.isEmpty(item.getDepartmentCode()))  {
             		info.setDepartmentCode(item.getDepartmentCode());
             	}
             	if(item.getReceptionNo() != null)  {
             		info.setReceptionNo(item.getReceptionNo().toString());
             	}
             	if(!StringUtils.isEmpty(item.getType()))  {
             		info.setType(item.getType());
             	}
             	if(!StringUtils.isEmpty(item.getDoctorCode()))  {
             		info.setDoctorCode(item.getDoctorCode());
             	}
             	if(!StringUtils.isEmpty(item.getResType()))  {
             		info.setResType(item.getResType());
             	}
             	if(!StringUtils.isEmpty(item.getResUserName()))  {
             		info.setResUserName(item.getResUserName());
             	}
             	if(!StringUtils.isEmpty(item.getResInputType()))  {
             		info.setResInputType(item.getResInputType());
             	}
             	if(!StringUtils.isEmpty(item.getComingStatus()))  {
             		info.setComingStatus(item.getComingStatus());
             	}
             	if(!StringUtils.isEmpty(item.getNewRow()))  {
             		info.setNewRow(item.getNewRow());
             	}
             	if(!StringUtils.isEmpty(item.getExamState()))  {
             		info.setExamState(item.getExamState());
             	}
             	if(!StringUtils.isEmpty(item.getExamIraiState()))  {
             		info.setExamIraiState(item.getExamIraiState());
             	}
             	if(!StringUtils.isEmpty(item.getResUser()))  {
             		info.setResUser(item.getResUser());
             	}
             	if(!StringUtils.isEmpty(item.getIpwonStatus()))  {
             		info.setIpwonStatus(item.getIpwonStatus());
             	}
             	if(!StringUtils.isEmpty(item.getReserComments()))  {
             		info.setReserComments(item.getReserComments());
             	}
             	if(!StringUtils.isEmpty(item.getReserType()))  {
             		info.setReserType(item.getReserType());
             	}
             	if(!StringUtils.isEmpty(item.getYoyangName()))  {
             		info.setClinicName(item.getYoyangName());
             	}
             	response.addReseredDataListItem(info);
             }
        }
		return response.build();
	}
}
