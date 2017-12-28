package nta.med.service.ihis.handler.chts;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.cht.Cht0117Repository;
import nta.med.data.model.ihis.chts.CHT0117GrdCHT0117InitListItemInfo;
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
public class CHT0117GrdCHT0117InitHandler extends ScreenHandler<ChtsServiceProto.CHT0117GrdCHT0117InitRequest, ChtsServiceProto.CHT0117GrdCHT0117InitResponse> {
    private static final Log LOGGER = LogFactory.getLog(CHT0117GrdCHT0117InitHandler.class);
    @Resource
    private Cht0117Repository cht0117Repository;

    @Override
    public boolean isValid(ChtsServiceProto.CHT0117GrdCHT0117InitRequest request, Vertx vertx, String clientId, String sessionId) {
        if (!StringUtils.isEmpty(request.getQueryDate()) && DateUtil.toDate(request.getQueryDate(), DateUtil.PATTERN_YYMMDD) == null) {
            return false;
        }
        
    	if(StringUtils.isEmpty(request.getOffset())){
			return false;
		}
        return true;
    }

    @Override
    @Transactional(readOnly = true)
    public ChtsServiceProto.CHT0117GrdCHT0117InitResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, ChtsServiceProto.CHT0117GrdCHT0117InitRequest request) throws Exception {
        ChtsServiceProto.CHT0117GrdCHT0117InitResponse.Builder response = ChtsServiceProto.CHT0117GrdCHT0117InitResponse.newBuilder();
        Integer startNum = CommonUtils.getStartNumberPaging(request.getPageNumber(), request.getOffset());
        List<CHT0117GrdCHT0117InitListItemInfo> listResult = cht0117Repository.getCHT0117GrdCHT0117InitListItem(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId),
                DateUtil.toDate(request.getQueryDate(), DateUtil.PATTERN_YYMMDD), request.getSearchWord(), startNum, CommonUtils.parseInteger(request.getOffset()));;
        if (!CollectionUtils.isEmpty(listResult)) {
            for (CHT0117GrdCHT0117InitListItemInfo item : listResult) {
                ChtsModelProto.CHT0117GrdCHT0117InitListItemInfo.Builder info = ChtsModelProto.CHT0117GrdCHT0117InitListItemInfo.newBuilder();
                BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                response.addListItemInfo(info);
            }
        }
        return response.build();
    }
}