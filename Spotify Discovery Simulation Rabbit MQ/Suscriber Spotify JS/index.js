var amqp = require('amqplib/callback_api')

amqp.connect('amqps://lqxiljlu:x1PcYflgxWmmOQvVhnJpKiQc9PZT3VXE@fly.rmq.cloudamqp.com/lqxiljlu', function (error0, connection) {
    if (error0) {
        throw error0
    }
    connection.createChannel(function (error1, channel) {
        if (error1) {
            throw error1
        }
        
        var queue = "Sebs"

        console.log(" [*] Waiting for messages in %s. To exit press CTRL+C", queue)
        channel.consume(queue, function (msg) {
            console.log(" [x] Recieved %s", msg.content.toString())
        }, {
            noAck: true
        })
    })
})