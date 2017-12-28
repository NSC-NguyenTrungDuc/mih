package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.out.Out0103Repository;
import nta.med.data.model.ihis.system.DetailPaInfoFormGridVisitListInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.DetailPaInfoFormGridVisitListRequest;
import nta.med.service.ihis.proto.SystemServiceProto.DetailPaInfoFormGridVisitListResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class DetailPaInfoFormGridVisitListHandler
	extends ScreenHandler<SystemServiceProto.DetailPaInfoFormGridVisitListRequest, SystemServiceProto.DetailPaInfoFormGridVisitListResponse>{
	@Resource
	private Out0103Repository out0103Repository;

	@Override
	@Transactional(readOnly = true)
	public DetailPaInfoFormGridVisitListResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			DetailPaInfoFormGridVisitListRequest request) throws Exception {
        List<DetailPaInfoFormGridVisitListInfo> listDetailPaInfoFormGridVisitListInfo = out0103Repository.getDetailPaInfoFormGridVisitList(getLanguage(vertx, sessionId), getHospitalCode(vertx, sessionId), request.getPatientCode());
        SystemServiceProto.DetailPaInfoFormGridVisitListResponse.Builder response = SystemServiceProto.DetailPaInfoFormGridVisitListResponse.newBuilder();
        if (listDetailPaInfoFormGridVisitListInfo != null && !listDetailPaInfoFormGridVisitListInfo.isEmpty()) {
            for (DetailPaInfoFormGridVisitListInfo obj : listDetailPaInfoFormGridVisitListInfo) {
            	SystemModelProto.DetailPaInfoFormGridVisitListInfo.Builder builder = SystemModelProto.DetailPaInfoFormGridVisitListInfo.newBuilder();
                BeanUtils.copyProperties(obj, builder, getLanguage(vertx, sessionId));
                response.addGridVisitItem(builder);
            }
        }
        return response.build();
	}
}
