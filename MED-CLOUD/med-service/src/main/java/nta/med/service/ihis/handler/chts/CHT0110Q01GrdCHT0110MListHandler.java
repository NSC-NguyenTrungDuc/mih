package nta.med.service.ihis.handler.chts;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.cht.Cht0110Repository;
import nta.med.data.model.ihis.chts.CHT0110Q01GrdCHT0110MListInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.ChtsModelProto;
import nta.med.service.ihis.proto.ChtsServiceProto;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;
import java.util.List;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class CHT0110Q01GrdCHT0110MListHandler extends ScreenHandler<ChtsServiceProto.CHT0110Q01GrdCHT0110MListRequest, ChtsServiceProto.CHT0110Q01GrdCHT0110MListResponse> {
	private static final Log LOGGER = LogFactory.getLog(CHT0110Q01GrdCHT0110MListHandler.class);
	@Resource                                                                                                       
	private Cht0110Repository cht0110Repository;

	@Override
	public boolean isValid(ChtsServiceProto.CHT0110Q01GrdCHT0110MListRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getDate()) && DateUtil.toDate(request.getDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}

	@Override
	@Transactional(readOnly = true)
	public ChtsServiceProto.CHT0110Q01GrdCHT0110MListResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, ChtsServiceProto.CHT0110Q01GrdCHT0110MListRequest request) throws Exception {
		ChtsServiceProto.CHT0110Q01GrdCHT0110MListResponse.Builder response = ChtsServiceProto.CHT0110Q01GrdCHT0110MListResponse.newBuilder();
		List<CHT0110Q01GrdCHT0110MListInfo> listGrd=cht0110Repository.getCHT0110Q01GrdCHT0110MListInfo(getHospitalCode(vertx, sessionId), request.getIoGubun(),
				request.getUserId(),request.getSangInx(),DateUtil.toDate(request.getDate(),DateUtil.PATTERN_YYMMDD));
		if(!CollectionUtils.isEmpty(listGrd)){
			for(CHT0110Q01GrdCHT0110MListInfo item:listGrd){
				ChtsModelProto.CHT0110Q01GrdCHT0110MListInfo.Builder info=ChtsModelProto.CHT0110Q01GrdCHT0110MListInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdListItem(info);
			}
		}
		return response.build();
	}
}