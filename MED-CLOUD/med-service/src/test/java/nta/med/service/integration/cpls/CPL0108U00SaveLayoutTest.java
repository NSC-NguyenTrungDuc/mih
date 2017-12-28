package nta.med.service.integration.cpls;

import nta.med.core.glossary.DataRowState;
import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.CplsModelProto;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.integration.MessageRequestTest;
import org.junit.Test;

/**
 * @author Tiepnm
 */
public class CPL0108U00SaveLayoutTest extends MessageRequestTest{
    @Test
    public void testCPL0108U00SaveLayout() throws InterruptedException {
        CplsModelProto.CPL0108U00InitGrdDetailListItemInfo.Builder grdDetailListItemInfo = CplsModelProto.CPL0108U00InitGrdDetailListItemInfo.newBuilder();
        grdDetailListItemInfo.setCodeType("04");
        grdDetailListItemInfo.setRowState(DataRowState.ADDED.getValue());
        CplsServiceProto.CPL0108U00SaveLayoutRequest request = CplsServiceProto.CPL0108U00SaveLayoutRequest
                .newBuilder().addInputList(grdDetailListItemInfo).setUserId("K01CPL")
                .build();
        sentRequestToMedApp(request, CplsServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
    }
}
