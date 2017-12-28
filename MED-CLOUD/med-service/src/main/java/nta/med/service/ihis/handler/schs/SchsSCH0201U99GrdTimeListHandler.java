package nta.med.service.ihis.handler.schs;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.sch.Sch0201Repository;
import nta.med.data.model.ihis.schs.SchsSCH0201U99GrdTimeListInfo;
import nta.med.service.ihis.proto.SchsModelProto;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.ihis.proto.SchsServiceProto.SchsSCH0201U99GrdTimeListRequest;
import nta.med.service.ihis.proto.SchsServiceProto.SchsSCH0201U99GrdTimeListResponse;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;
import java.util.List;

@Service
@Scope("prototype")
public class SchsSCH0201U99GrdTimeListHandler
        extends ScreenHandler<SchsServiceProto.SchsSCH0201U99GrdTimeListRequest, SchsServiceProto.SchsSCH0201U99GrdTimeListResponse> {
    @Resource
    private Sch0201Repository sch0201Repository;

    @Override
    @Transactional(readOnly = true)
    public SchsSCH0201U99GrdTimeListResponse handle(Vertx vertx,
                                                    String clientId, String sessionId, long contextId,
                                                    SchsSCH0201U99GrdTimeListRequest request) throws Exception {
        SchsServiceProto.SchsSCH0201U99GrdTimeListResponse.Builder response = SchsServiceProto.SchsSCH0201U99GrdTimeListResponse.newBuilder();
        String hospCode = getHospitalCode(vertx, sessionId);
        if(!StringUtils.isEmpty(request.getOutHospcode()))
        {
            hospCode = request.getOutHospcode();
        }
        List<SchsSCH0201U99GrdTimeListInfo> listResult = sch0201Repository.getSchsSCH0201U99GrdTimeListInfo(hospCode, request.getIpAddr());
        if (listResult != null && !listResult.isEmpty()) {
            for (SchsSCH0201U99GrdTimeListInfo item : listResult) {
                SchsModelProto.SchsSCH0201U99GrdTimeListInfo.Builder info = SchsModelProto.SchsSCH0201U99GrdTimeListInfo.newBuilder();
                if (!StringUtils.isEmpty(item.getFromTime())) {
                    info.setFromTime(item.getFromTime());
                }
                if (!StringUtils.isEmpty(item.getBunho())) {
                    info.setBunho(item.getBunho());
                }
                if (!StringUtils.isEmpty(item.getSuname())) {
                    info.setSuname(item.getSuname());
                }
                if (!StringUtils.isEmpty(item.getHangmogName())) {
                    info.setHangmogName(item.getHangmogName());
                }
                if (!StringUtils.isEmpty(item.getDoctorName())) {
                    info.setDoctorName(item.getDoctorName());
                }
                if (!StringUtils.isEmpty(item.getInputDate())) {
                    info.setInputDate(item.getInputDate().toString());
                }
                if (!StringUtils.isEmpty(item.getOrderDate())) {
                    info.setOrderDate(item.getOrderDate().toString());
                }
                if (!StringUtils.isEmpty(item.getReserDate())) {
                    info.setReserDate(item.getReserDate().toString());
                }
                if (!StringUtils.isEmpty(item.getPksch0201())) {
                    info.setPksch0201(String.format("%.0f", item.getPksch0201()));
                }
                if (!StringUtils.isEmpty(item.getOutHospCode())) {
                    info.setOutHospCode(item.getOutHospCode());
                }
                if (!StringUtils.isEmpty(item.getYoyangName())) {
                    info.setYoyangName(item.getYoyangName());
                }
                response.addOrderList(info);
            }
        }
        return response.build();
    }
}
