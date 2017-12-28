package nta.med.service.integration.ocsa;


import nta.med.core.glossary.DataRowState;
import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.integration.MessageRequestTest;
import org.junit.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.vertx.java.core.Vertx;


public class OCS0101U00TransactionalTest extends MessageRequestTest {
    @Autowired
    protected Vertx vertx;

    @Test
    public void testOCS0101U00Transactional() throws InterruptedException {
        OcsaModelProto.OCS0101U00GrdOcs0101ListItemInfo.Builder info1 = OcsaModelProto.OCS0101U00GrdOcs0101ListItemInfo.newBuilder();
        info1.setSlipGubun("Q1");

        info1.setRowState(DataRowState.ADDED.getValue());
        OcsaServiceProto.OCS0101U00TransactionalRequest request = OcsaServiceProto.OCS0101U00TransactionalRequest
                .newBuilder()
                .addListGrdOcs0101(info1)
                .setUserId("TEST")
                .build();
        sentRequestToMedApp(request, OcsaServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));

    }
}